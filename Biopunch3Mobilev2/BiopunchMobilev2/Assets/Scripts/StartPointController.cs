using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPointController : MonoBehaviour
{
    public int PlayerID = 0;
    public GameObject CubePrefab;

    // Start is called before the first frame update
    void Start()
    {
        Renderer rend = GetComponent<Renderer>();

        if (PlayerID == 0)
        {
            rend.material.color = new Color(1f, 0f, 0.3f, 1);
        }
        else if (PlayerID == 1)
        {
            rend.material.color = new Color(0.16f, 0.67f, 1f, 1);
        }
        else if (PlayerID == 2)
        {
            rend.material.color = new Color(0f, 0.89f, 0.21f, 1);
        }
        else if (PlayerID == 3)
        {
            rend.material.color = new Color(1f, 0.93f, 0.15f, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject PlaceNextCube(RaycastHit hit, GameManager.PlayerColor color)
    {
        Vector3 positionInGrid = GridManager.instance.GetPositionInGrid(transform.localPosition);

        bool canPlace = true;

        if (Mathf.RoundToInt(positionInGrid.x) < 0 || Mathf.RoundToInt(positionInGrid.x) >= GridManager.instance.Dimension)
            canPlace = false;
        else if (Mathf.RoundToInt(positionInGrid.y) < 0 || Mathf.RoundToInt(positionInGrid.y) >= GridManager.instance.Dimension)
            canPlace = false;
        else if (Mathf.RoundToInt(positionInGrid.z) < 0 || Mathf.RoundToInt(positionInGrid.z) >= GridManager.instance.Dimension)
            canPlace = false;

        if (canPlace == false)
            return null;

        GameObject nextCube;
        nextCube = Instantiate(CubePrefab, transform.position, transform.rotation);
        nextCube.transform.parent = transform.parent;
        nextCube.GetComponent<CubeController>().SetCubeColor(color);
        nextCube.GetComponent<CubeController>().PlaceCube(positionInGrid);

        nextCube.GetComponent<CubeController>().SetGlow(GameManager.instance.gridManager.GlowValue);

        return nextCube;
    }
}
