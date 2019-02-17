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
            canPlace = false;
        else if (GameManager.instance.lastCubes[GameManager.instance.GetCurrentPlayer()] != null && this != GameManager.instance.lastCubes[GameManager.instance.GetCurrentPlayer()])
            canPlace = false;

        if (canPlace == false)
            return null;

        if (GameManager.instance.lastCubes[GameManager.instance.GetCurrentPlayer()] == null)
        {
            GameManager.instance.StopGlow();
        }

        GameObject nextCube;
        nextCube = Instantiate(CubePrefab, transform.position + hit.normal * GridManager.instance.SizeCube, transform.rotation);
        nextCube.transform.parent = transform.parent;
        nextCube.GetComponent<CubeController>().SetCubeColor(color);
        nextCube.GetComponent<CubeController>().PlaceCube(positionInGrid);

        SetGlow(GameManager.instance.gridManager.noGlowValue);
        nextCube.GetComponent<CubeController>().SetGlow(GameManager.instance.gridManager.GlowValue);

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

        Material[] mats;
        mats = GetComponent<Renderer>().materials;

        if (color == GameManager.PlayerColor.eColorOne)
        {
            mats[1] = GameManager.instance.MaterialsPlayersGalaxies[0];
            mats[5] = GameManager.instance.MaterialsPlayers[0];
            GetComponent<Renderer>().materials = mats;
        }
        else if (color == GameManager.PlayerColor.eColorTwo)
        {
            mats[1] = GameManager.instance.MaterialsPlayersGalaxies[1];
            mats[5] = GameManager.instance.MaterialsPlayers[1];
            GetComponent<Renderer>().materials = mats;
        }
        else if (color == GameManager.PlayerColor.eColorThree)
        {
            mats[1] = GameManager.instance.MaterialsPlayersGalaxies[2];
            mats[5] = GameManager.instance.MaterialsPlayers[2];
            GetComponent<Renderer>().materials = mats;
        }
        else if (color == GameManager.PlayerColor.eColorFour)
        {
            mats[1] = GameManager.instance.MaterialsPlayersGalaxies[3];
            mats[5] = GameManager.instance.MaterialsPlayers[3];
            GetComponent<Renderer>().materials = mats;
        }
    }

    public void SetGlow(float glowValue)
    {
        Material[] mats;
        mats = GetComponent<Renderer>().materials;

        mats[5].SetFloat("Vector1_4C82A84B", glowValue);
    }
}
