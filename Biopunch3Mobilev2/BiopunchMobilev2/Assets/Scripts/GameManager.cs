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

    public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
    public GameObject[] players;
    public int MAX_PLAYERS = 0;
    public int TIME_POINT_FACTOR = 1;
    private int[] playerScores;
    private int currentPlayerIndex = 0;
    private PlayerTimer[] playerTimers;
    private GameObject[] latestPlayerBlock;
    private PlayerColor[] playersColor;

    public GameplayManager gameplayManager;

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

        
    }

    public void AddPointToCurrentPlayer(int points)
    {
        object t = playerTimers[currentPlayerIndex].GetElapsedTime();
        int weightedPoint = points + (int) Mathf.Abs((TIME_POINT_FACTOR / playerTimers[currentPlayerIndex].GetElapsedTime()));
        playerScores[currentPlayerIndex] += weightedPoint;

        Debug.Log("AddPointToCurrentPlayer Player Index:" + currentPlayerIndex + "Score:" + GetPlayerScore(currentPlayerIndex));
    }

    public void GoToNextPlayer()
    {
        currentPlayerIndex = (currentPlayerIndex+1) % MAX_PLAYERS;
        playerTimers[currentPlayerIndex].Reset();
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

    // Update is called once per frame
    void Update()
    {
        float t = playerTimers[currentPlayerIndex].GetElapsedTime();
        if (t > TIME_POINT_FACTOR)
        {
            gameplayManager.UndoAllBlocks();
            GoToNextPlayer();
        }

        //AddPointToCurrentPlayer(1);
        ////Debug.Log("Player Index:" +currentPlayerIndex + "Score:" + GetPlayerScore(currentPlayerIndex));
        //GoToNextPlayer();
    }
}
