﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public float SizeCube = 1;
    public int Dimension = 16;

    CubeController[,,] Grid;

    public static GridManager instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        Grid = new CubeController[Dimension, Dimension, Dimension];
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 GetPositionInGrid(Vector3 cubeLocalPosition)
    {
        float x = (cubeLocalPosition.x + ((SizeCube * Dimension) / 2) - (SizeCube / 2)) / SizeCube;
        float y = ((cubeLocalPosition.y * -1) + ((SizeCube * Dimension) / 2) - (SizeCube / 2)) / SizeCube;
        float z = (cubeLocalPosition.z + ((SizeCube * Dimension) / 2) - (SizeCube / 2)) / SizeCube;

        return new Vector3(x, y, z);
    }

    public void AddToGrid(CubeController cube, int x, int y, int z)
    {
        Grid[x,y,z] = cube;
    }
}
