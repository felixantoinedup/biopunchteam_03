using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public GameObject Arena;
    public GameObject ArenaRotator;
    public float RotationSpeed = 100;
    public float MinZoom = 30;
    public float MaxZoom = 90;
    public bool fpsControl = false;
    public float mouseZoomMul = 10f;

    public float perspectiveZoomSpeed = 0.5f;        // The rate of change of the field of view in perspective mode.
    public float orthoZoomSpeed = 0.5f;        // The rate of change of the orthographic size in orthographic mode.

    public float RotationSpeedPC = 10000;

    public UIController uicontroller;


    //fps controls
    Vector2 mouseLook;
    Vector2 smoothV;

    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;

    public void UndoAllBlocks()
    {
        foreach (CubeController obj in GameManager.instance.currentBlocksPlaced)
        {
            try
            {
                if (obj != null) Destroy(obj.gameObject);
            }
            catch
            {
                continue;
            }
        }

        GameManager.instance.currentBlocksPlaced.Clear();
    }

    private void UndoLastBlock()
    {
        if(GameManager.instance.currentBlocksPlaced.Count > 0)
        {
            Destroy(GameManager.instance.currentBlocksPlaced.Pop().gameObject);

            if (GameManager.instance.currentBlocksPlaced.Count > 0)
            {
                GameManager.instance.lastCubes[GameManager.instance.GetCurrentPlayer()] = GameManager.instance.currentBlocksPlaced.Peek();
            }
            else
            {
                GameManager.instance.lastCubes[GameManager.instance.GetCurrentPlayer()] = GameManager.instance.tempLastCube;
                GameManager.instance.gridManager.GlowAllPlayerCube();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.triggerGameplay)
            return;

        // If there are two touches on the device...
        if (Input.touchCount == 2 || Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            Zoom();
        }
        else
        {
            if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButtonDown(0))
            {
                PlaceCube();
            }

            if (Input.GetMouseButton(0))
            {
                Rotate();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                if (!fpsControl)
                {
                    Arena.transform.parent = null;
                    ArenaRotator.transform.rotation = Quaternion.identity;
                    Arena.transform.parent = ArenaRotator.transform;
                }
            }
            else if(Input.GetKeyDown("space"))
            {
                PressDone();
            }
            else if(Input.GetKeyDown("backspace"))
            {
                PressRevert();
            }

            if(!fpsControl)
            {
                //Arena.transform.parent = null;
                //ArenaRotator.transform.rotation = Quaternion.identity;
                //Arena.transform.parent = ArenaRotator.transform;
            }
        }
    }

    void Zoom()
    {
        float deltaMagnitudeDiff;

        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            deltaMagnitudeDiff = -Input.GetAxis("Mouse ScrollWheel") * mouseZoomMul;
        }
        else
        {
            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
        }


        // If the camera is orthographic...
        if (Camera.main.orthographic)
        {
            // ... change the orthographic size based on the change in distance between the touches.
            Camera.main.orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed;

            // Make sure the orthographic size never drops below zero.
            Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize, 0.1f);
        }
        else
        {
            // Otherwise change the field of view based on the change in distance between the touches.
            Camera.main.fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;

            // Clamp the field of view to make sure it's between 0 and 180.
            Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, MinZoom, MaxZoom);
        }
    }

    void Rotate()
    {
        if(fpsControl)
        {
            Vector2 md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
            md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
            smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
            smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
            mouseLook += smoothV;
            mouseLook.y = Mathf.Clamp(mouseLook.y, -90, 90);

            Arena.transform.localRotation = Quaternion.AngleAxis(-mouseLook.x, Vector3.up);
            ArenaRotator.transform.localRotation = Quaternion.AngleAxis(mouseLook.y, Vector3.right);
        }
        else
        {
            float rotX = Input.GetAxis("Mouse X") * RotationSpeedPC * Mathf.Deg2Rad * Time.deltaTime;
            float rotY = Input.GetAxis("Mouse Y") * RotationSpeedPC * Mathf.Deg2Rad * Time.deltaTime;

            if (Input.touchCount > 0)
            {
                rotX = Input.touches[0].deltaPosition.x * RotationSpeed * Mathf.Deg2Rad * Time.deltaTime;
                rotY = Input.touches[0].deltaPosition.y * RotationSpeed * Mathf.Deg2Rad * Time.deltaTime;
            }

            Quaternion target = Quaternion.Euler(rotY, -rotX, 0);
            ArenaRotator.transform.rotation = ArenaRotator.transform.rotation * target;

            //Arena.transform.Rotate(Vector3.up, -rotX, Space.World);
            //Arena.transform.Rotate(Vector3.right, rotY, Space.World);
        }
    }

    void PlaceCube()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            if(hit.collider.tag == "StartPoint")
            {
                if(hit.collider.gameObject.GetComponent<StartPointController>().PlayerID == GameManager.instance.GetCurrentPlayer())
                {
                    GameObject cube = null;
                    cube = hit.collider.GetComponent<StartPointController>().PlaceNextCube(hit, GameManager.instance.GetPlayerColor(GameManager.instance.GetCurrentPlayer()));
                    if (null != cube)
                    {
                        GameManager.instance.currentBlocksPlaced.Push(cube.GetComponent<CubeController>());
                        GameManager.instance.lastCubes[GameManager.instance.GetCurrentPlayer()] = cube.GetComponent<CubeController>();
                    }
                }
            }
            else if (GameManager.instance.GetPlayerColor(GameManager.instance.GetCurrentPlayer()) == hit.collider.GetComponent<CubeController>().cubeColor)
            {
                GameObject cube = null;
                cube = hit.collider.GetComponent<CubeController>().PlaceNextCube(hit, GameManager.instance.GetPlayerColor(GameManager.instance.GetCurrentPlayer()));
                //GameManager.instance.GoToNextPlayer();
                //GameManager.instance.AddPointToCurrentPlayer(1);
                if(null != cube)
                {
                    GameManager.instance.currentBlocksPlaced.Push(cube.GetComponent<CubeController>());
                    GameManager.instance.lastCubes[GameManager.instance.GetCurrentPlayer()] = cube.GetComponent<CubeController>();
                }
            }
        }
    }

    public void PressDone()
    {
        GameManager.instance.GoToNextPlayer(true);
        GameManager.instance.AddPointToCurrentPlayer(GameManager.instance.currentBlocksPlaced.Count);
        GameManager.instance.currentBlocksPlaced.Clear();
        CallReadyPrompt();
    }

    public void CallReadyPrompt()
    {
        uicontroller.ShowReady();
    }

    public void PressRevert()
    {
        UndoLastBlock();
    }
}
