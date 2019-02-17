using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum PlayerColor
    {
        eColorOne,
        eColorTwo,
        eColorThree,
        eColorFour,
        LAST_COLOR
    }

    public string GetColorString(PlayerColor pc)
    {
        switch (pc)
        {
            case PlayerColor.eColorOne:
                return "Red";
            case PlayerColor.eColorTwo:
                return "Blue";
            case PlayerColor.eColorThree:
                return "Green";
            case PlayerColor.eColorFour:
                return "Yellow"; 
        }
        return "None";
    }

    public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
    public GameObject[] players;
    public CubeController[] startingCubes;
    public Material[] MaterialsPlayers;
    public Material[] MaterialsPlayersGalaxies;
    public int MAX_PLAYERS = 0;
    public int TIME_POINT_FACTOR = 1;
    public int pointsToWinner = 50;
    public bool onlyLastCube = true;
    public GameObject prefabLegacy;
    public Animator animationController;
    public int latestWinner = 0;

    [HideInInspector]
    public CubeController[] lastCubes;
    [HideInInspector]
    public CubeController tempLastCube = null;
    [HideInInspector]
    public Stack<CubeController> currentBlocksPlaced = new Stack<CubeController>();
    [HideInInspector]
    public Stack<CubeController> stackForLegacy = new Stack<CubeController>();
    [HideInInspector]
    public CubeController cubeForLegacy = null;
    [HideInInspector]
    public bool triggerGameplay = false;
    [HideInInspector]
    public int compteurSkip = 0;

    private int[] playerScores;
    private int currentPlayerIndex = 0;
    private PlayerTimer[] playerTimers;
    private CubeController[] latestPlayerCube;
    private PlayerColor[] playersColor;

    public GameplayManager gameplayManager;
    public GridManager gridManager;
    public UIController uiController;


    public AudioSource musicSource;                 //Drag a reference to the audio source which will play the music.

    //Awake is always called before any Start functions
    void Awake()
        {
            //Check if instance already exists
            if (instance == null)

                //if not, set instance to this
                instance = this;

            //If instance already exists and it's not this:
            else if (instance != this)

                //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
                Destroy(gameObject);

            //Sets this to not be destroyed when reloading scene
            DontDestroyOnLoad(gameObject);

            InitGame();
        }


    //Initializes the game for each level.
    void InitGame()
    {
        playerTimers = new PlayerTimer[4]; //
        int i = 0;
        foreach (GameObject p in players)
        {
            playerTimers[i] = p.GetComponent(typeof(PlayerTimer)) as PlayerTimer; 
            ++i;
        }

        // DEBUG: OVERRIDE DEFAULT STUFFS 
        if (MAX_PLAYERS == 0)
            MAX_PLAYERS = 4;

        if (TIME_POINT_FACTOR == 1)
            TIME_POINT_FACTOR = 10;

        playerScores = new int[MAX_PLAYERS];
        playersColor = new PlayerColor[MAX_PLAYERS];

        // Setup first player color
        i = 0;
        PlayerColor lastColor = PlayerColor.eColorOne;
        foreach (GameObject p in players)
        {
            if (0 == i)
            {
                // STOP THE RANDOM!!!
                //PlayerColor randomColor = (PlayerColor)Random.Range(0, (int)PlayerColor.LAST_COLOR - 1);
                //playersColor[i] = randomColor;
                playersColor[i] = lastColor;
            }
            else
            {
                PlayerColor newColor = lastColor + 1;
                if(newColor == PlayerColor.LAST_COLOR)
                {
                    ++newColor;
                }
                playersColor[i] = newColor;
            }
            lastColor = playersColor[i];
            ++i;
        }

        lastCubes = new CubeController[MAX_PLAYERS];

        //for (int j = 0; j < startingCubes.Length; j++)
        //{
        //    startingCubes[j].SetCubeColor((PlayerColor)j);
        //    lastCubes[j] = startingCubes[j];
        //}

        //tempLastCube = lastCubes[0];

        StopPlay();

        musicSource.Play();
    }

    public void resetGame()
    {
        currentPlayerIndex = 0;
        latestWinner = 0;
        spawnLegacyCubes();
        lastCubes = new CubeController[MAX_PLAYERS];
        tempLastCube = null;
        currentBlocksPlaced.Clear();
        stackForLegacy.Clear();
        triggerGameplay = false;
        compteurSkip = 0;
        cubeForLegacy = null;
        gridManager.ResetGrid();
        uiController.ShowReady();
    }

    public void AddPointToCurrentPlayer(int points)
    {
        object t = playerTimers[currentPlayerIndex].GetElapsedTime();
        int weightedPoint = points * Mathf.CeilToInt(TIME_POINT_FACTOR - playerTimers[currentPlayerIndex].GetElapsedTime());
        playerScores[currentPlayerIndex] += weightedPoint;
    }

    public void GoToNextPlayer(bool placedBlock)
    {
        if(onlyLastCube)
        {
            if (!placedBlock)
            {
                lastCubes[currentPlayerIndex] = tempLastCube;
            }

            tempLastCube = lastCubes[currentPlayerIndex];
        }
        else
        {
            lastCubes[currentPlayerIndex] = null;
        }

        if (placedBlock)
        {
            compteurSkip = 0;
            animationController.SetInteger("YayIntRandom", Random.Range(0, 3));
            animationController.SetTrigger("Yay");
        }
        else
        {
            ++compteurSkip;
        }
            

        if(compteurSkip >= MAX_PLAYERS - 1)
        {
            EndPlay();
        }
        else if (compteurSkip > 0)
        {
            animationController.SetInteger("NayIntRandom", Random.Range(0, 2));
            animationController.SetTrigger("Nay");
        }
       

        gridManager.StopGlowAllPlayerCube();

        currentPlayerIndex = (currentPlayerIndex+1) % MAX_PLAYERS;
        playerTimers[currentPlayerIndex].Reset();

        gridManager.GlowAllPlayerCube();
    }

    public int GetPlayerScore(int index)
    {
        return playerScores[index];
    }

    public PlayerColor GetPlayerColor(int index)
    {
        return playersColor[index];
    }

    public int GetCurrentPlayer()
    {
        return currentPlayerIndex;
    }

    public float GetCurrentPlayerTimer()
    {
        return (float) TIME_POINT_FACTOR - playerTimers[currentPlayerIndex].GetElapsedTime();
    }

    public void StartPlay()
    {
        EnableGameplay();

        foreach (PlayerTimer pt in playerTimers)
        {
            pt.Reset();
            pt.StartTimer();
        }
    }

    public void StopPlay()
    {
        DisableGameplay();

        foreach (PlayerTimer pt in playerTimers)
        {
            pt.StopTimer();
        }
    }

    public void EndPlay()
    {
        animationController.SetTrigger("EndGame");

        playerScores[latestWinner] += pointsToWinner;
        uiController.ShowGameOver();

        DisableGameplay();

        foreach (PlayerTimer pt in playerTimers)
        {
            pt.StopTimer();
        }

        gameplayManager.CallGameOverPrompt();
    }

    // Update is called once per frame
    void Update()
    {
        if (!triggerGameplay)
            return;

        float t = playerTimers[currentPlayerIndex].GetElapsedTime();
        //Debug.Log("Player:" + currentPlayerIndex + " Timer:" + t);
        if (t > TIME_POINT_FACTOR)
        {
            gameplayManager.UndoAllBlocks();
            GoToNextPlayer(false);

            if(compteurSkip < MAX_PLAYERS - 1)
                gameplayManager.CallReadyPrompt();
        }

        //AddPointToCurrentPlayer(1);
        ////Debug.Log("Player Index:" +currentPlayerIndex + "Score:" + GetPlayerScore(currentPlayerIndex));
        //GoToNextPlayer();
    }

    public void StopGlow()
    {
        gridManager.StopGlowAllPlayerCube();
    }

    public void EnableGameplay()
    {
        triggerGameplay = true;
    }

    public void DisableGameplay()
    {
        triggerGameplay = false;
    }

    public void spawnLegacyCubes()
    {
        if (cubeForLegacy == null)
            return;

        int x = cubeForLegacy.PositionInGridX;
        int y = cubeForLegacy.PositionInGridY;
        int z = cubeForLegacy.PositionInGridZ;

        GameObject legacyCube;
        legacyCube = Instantiate(prefabLegacy, cubeForLegacy.transform.position, cubeForLegacy.transform.rotation);
        legacyCube.transform.parent = cubeForLegacy.transform.parent;

        gridManager.RemoveFromGrid(x, y, z);
        legacyCube.GetComponent<CubeController>().PlaceCube(new Vector3(x, y, z));

        //foreach (CubeController obj in stackForLegacy)
        //{
        //    int x = obj.PositionInGridX;
        //    int y = obj.PositionInGridY;
        //    int z = obj.PositionInGridZ;

        //    GameObject legacyCube;
        //    legacyCube = Instantiate(prefabLegacy, obj.transform.position, obj.transform.rotation);
        //    legacyCube.transform.parent = obj.transform.parent;

        //    gridManager.RemoveFromGrid(x,y,z);
        //    legacyCube.GetComponent<CubeController>().PlaceCube(new Vector3 (x,y,z));
        //}
    }

    public void copyStack()
    {

    }
}
