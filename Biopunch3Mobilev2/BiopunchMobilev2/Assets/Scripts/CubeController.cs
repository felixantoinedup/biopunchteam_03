using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public int PlayerID = 0;
    public int PositionInGridX = 0;
    public int PositionInGridY = 0;
    public int PositionInGridZ = 0;

    public GameObject CubePrefab;

    public GameManager.PlayerColor cubeColor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.position);
    }

    public GameObject PlaceNextCube(RaycastHit hit, GameManager.PlayerColor color)
    {
        Vector3 positionInGrid = GridManager.instance.GetPositionInGrid(transform.parent.InverseTransformPoint(transform.position + hit.normal * GridManager.instance.SizeCube));

        bool canPlace = true;

        if (Mathf.RoundToInt(positionInGrid.x) < 0 || Mathf.RoundToInt(positionInGrid.x) >= GridManager.instance.Dimension)
            canPlace = false;
        else if (Mathf.RoundToInt(positionInGrid.y) < 0 || Mathf.RoundToInt(positionInGrid.y) >= GridManager.instance.Dimension)
            canPlace = false;
        else if (Mathf.RoundToInt(positionInGrid.z) < 0 || Mathf.RoundToInt(positionInGrid.z) >= GridManager.instance.Dimension)
            canPlace = false;

        if (GameManager.instance.onlyLastCube && this != GameManager.instance.lastCubes[GameManager.instance.GetCurrentPlayer()])
        {
            canPlace = false;
        }

        if (canPlace == false)
            return null;

        GameObject nextCube;
        nextCube = Instantiate(CubePrefab, transform.position + hit.normal * GridManager.instance.SizeCube, transform.rotation);
        nextCube.transform.parent = transform.parent;
        nextCube.GetComponent<CubeController>().SetCubeColor(color);
        nextCube.GetComponent<CubeController>().PlaceCube(positionInGrid);

        return nextCube;
    }

    public void PlaceCube(Vector3 positionInGrid)
    {
        SetPositionInGrid(positionInGrid);
        SetInGrid();
    }

    void SetPositionInGrid(Vector3 positionInGrid)
    {
        PositionInGridX = Mathf.RoundToInt(positionInGrid.x);
        PositionInGridY = Mathf.RoundToInt(positionInGrid.y);
        PositionInGridZ = Mathf.RoundToInt(positionInGrid.z);
    }

    void SetInGrid()
    {
        GridManager.instance.AddToGrid(this, PositionInGridX, PositionInGridY, PositionInGridZ);
    }

    public void SetCubeColor(GameManager.PlayerColor color)
    {
        cubeColor = color;

        Renderer rend = GetComponent<Renderer>();

        if (color == GameManager.PlayerColor.eColorOne)
        {
            rend.material.color = new Color(0.16f, 0.67f, 1f, 1);
        }
        else if (color == GameManager.PlayerColor.eColorTwo)
        {
            rend.material.color = new Color(1f, 0f, 0.3f, 1);
        }
        else if (color == GameManager.PlayerColor.eColorThree)
        {
            rend.material.color = new Color(0f, 0.89f, 0.21f, 1);
        }
        else if (color == GameManager.PlayerColor.eColorFour)
        {
            rend.material.color = new Color(1f, 0.93f, 0.15f, 1);
        }
    }
}
