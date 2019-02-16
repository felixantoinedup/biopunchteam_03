﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public int PlayerID = 0;
    public int PositionInGridX = 0;
    public int PositionInGridY = 0;
    public int PositionInGridZ = 0;

    public GameObject CubePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaceNextCube(RaycastHit hit)
    {
        Vector3 positionInGrid = GridManager.instance.GetPositionInGrid(transform.parent.InverseTransformPoint(transform.position + hit.normal * GridManager.instance.SizeCube));
        bool canPlace = true;

        if (Mathf.RoundToInt(positionInGrid.x) < 0 || Mathf.RoundToInt(positionInGrid.x) >= GridManager.instance.Dimension)
            canPlace = false;
        else if (Mathf.RoundToInt(positionInGrid.y) < 0 || Mathf.RoundToInt(positionInGrid.y) >= GridManager.instance.Dimension)
            canPlace = false;
        else if (Mathf.RoundToInt(positionInGrid.z) < 0 || Mathf.RoundToInt(positionInGrid.z) >= GridManager.instance.Dimension)
            canPlace = false;

        if (canPlace == false)
            return;

        GameObject nextCube;
        nextCube = Instantiate(CubePrefab, transform.position + hit.normal * GridManager.instance.SizeCube, transform.rotation);
        nextCube.transform.parent = transform.parent;

        nextCube.GetComponent<CubeController>().PlaceCube(positionInGrid);
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
