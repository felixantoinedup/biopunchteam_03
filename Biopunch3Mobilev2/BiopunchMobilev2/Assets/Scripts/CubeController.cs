using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public int PlayerID = 0;
    public Vector3 PositionInGrid;

    public GameObject CubePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.position);
    }

    public void PlaceNextCube(RaycastHit hit)
    {
        GameObject nextCube;
        nextCube = Instantiate(CubePrefab, transform.position + hit.normal * 1, transform.rotation);
        nextCube.transform.parent = transform.parent;
    }
}
