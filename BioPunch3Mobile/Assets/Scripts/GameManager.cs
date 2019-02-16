using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
    public GameObject[] players;
    public int MAX_PLAYERS = 0;
    public int TIME_POINT_FACTOR = 1;
    private int[] playerScores;
    private int currentPlayerIndex = 0;
    private PlayerTimer[] playerTimers;

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
            playerTimers[i] = p.GetComponent(typeof(PlayerTimer)) as PlayerTimer; ;
            ++i;
        }

        if (MAX_PLAYERS == 0)
            MAX_PLAYERS = 4;

        if (TIME_POINT_FACTOR == 1)
            TIME_POINT_FACTOR = 10;

        playerScores = new int[MAX_PLAYERS]; 
    }

    void AddPointToCurrentPlayer(int points)
    {
        object t = playerTimers[currentPlayerIndex].GetElapsedTime();
        int weightedPoint = points + (int) Mathf.Abs((TIME_POINT_FACTOR / playerTimers[currentPlayerIndex].GetElapsedTime()));
        playerScores[currentPlayerIndex] += weightedPoint;
    }

    void GoToNextPlayer()
    {
        currentPlayerIndex = (currentPlayerIndex+1) % MAX_PLAYERS;
    }

    int GetPlayerScore(int index)
    {
        return playerScores[index];
    }

    // Update is called once per frame
    void Update()
    {
        //AddPointToCurrentPlayer(1);
        ////Debug.Log("Player Index:" +currentPlayerIndex + "Score:" + GetPlayerScore(currentPlayerIndex));
        //GoToNextPlayer();
    }
}
