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

    public void PlaceNextCube(RaycastHit hit, GameManager.PlayerColor color)
    {
        cubeColor = color;
        GameObject nextCube;
        nextCube = Instantiate(CubePrefab, transform.position + hit.normal * GridManager.instance.SizeCube, transform.rotation);
        nextCube.transform.parent = transform.parent;

        Renderer rend = nextCube.GetComponent<Renderer>();

        if(color == GameManager.PlayerColor.eColorOne)
        {

            //Set the main Color of the Material to green
            //rend.material.shader = Shader.Find("_Color");
            //rend.material.SetColor("_Color", Color.green/255);
            ////gameObject.GetComponent().material.color = new Color(0, 0, 1, 1);
            rend.material.color = new Color(0, 0, 1, 1);

        }
        if (color == GameManager.PlayerColor.eColorTwo)
        {

            ////Set the main Color of the Material to green
            //rend.material.shader = Shader.Find("_Color");
            //rend.material.SetColor("_Color", Color.yellow / 255);
            rend.material.color = new Color(1, 0, 1, 1);
        }
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
}
