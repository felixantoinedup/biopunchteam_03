using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public enum MCFace
    {
        None,
        Up,
        Down,
        East,
        West,
        North,
        South
    }

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
        MCFace faceClicked = GetHitFace(hit);
        Vector3 localDirNextCube;

        switch (faceClicked)
        {
            case MCFace.Down:
                localDirNextCube = Vector3.down;
                break;
            default:
                print("Incorrect intelligence level.");
                break;
        }
    }

    public MCFace GetHitFace(RaycastHit hit)
    {
        Vector3 incomingVec = hit.normal - Vector3.up;

        if (incomingVec == new Vector3(0, -1, -1))
            return MCFace.South;

        if (incomingVec == new Vector3(0, -1, 1))
            return MCFace.North;

        if (incomingVec == new Vector3(0, 0, 0))
            return MCFace.Up;

        if (incomingVec == new Vector3(0, -2, 0))
            return MCFace.Down;

        if (incomingVec == new Vector3(-1, -1, 0))
            return MCFace.West;

        if (incomingVec == new Vector3(1, -1, 0))
            return MCFace.East;

        return MCFace.None;
    }
}
