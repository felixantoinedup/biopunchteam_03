using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Canvas CanvasInGame;
    public Canvas CanvasIntermission;
    public Canvas CanvasGameOver;
    public Text TimerText;
    public Image playerColorIndicator;
    public Text Score1Text;
    public Text Score2Text;
    public Text Score3Text;
    public Text Score4Text;


    // Start is called before the first frame update
    void Start()
    {
        ShowReady();
    }

    public void ShowReady()
    {
        CanvasInGame.enabled = false;
        CanvasIntermission.enabled = true;
        CanvasGameOver.enabled = false;
        GameManager.instance.StopPlay();
    }

    public void ShowGameOver()
    {
        CanvasInGame.enabled = false;
        CanvasIntermission.enabled = false;
        CanvasGameOver.enabled = true;
        GameManager.instance.StopPlay();
    }

    public void PressReady()
    {
        GameManager.instance.StartPlay();
        CanvasInGame.enabled = true;
        CanvasGameOver.enabled = false;
        CanvasIntermission.enabled = false;
    }

    public void PressReplay()
    {
        GameManager.instance.StartPlay();
        CanvasInGame.enabled = true;
        CanvasIntermission.enabled = false;
        CanvasGameOver.enabled = false;
    }

    public void PressEndGame()
    {
        CanvasInGame.enabled = false;
        CanvasIntermission.enabled = false;
        CanvasGameOver.enabled = true;
        GameManager.instance.EndPlay();
    }

    int ElementAt(System.Collections.Generic.SortedDictionary<int, string> dict, int i) // Dunno what is your dictionary types...
    {
        int index = 0;
        foreach (var kvp in dict)
        {
            index++;
            if (index == i)
            {
                return kvp.Key;  // According to question, you are after the key 
            }
        }
        return 0;
    }


    public class Score : System.IComparable
    {
        public int score;
        public GameManager.PlayerColor playerName;

        public Score(int score, GameManager.PlayerColor playerName)
        {
            this.score = score;
            this.playerName = playerName;
        }

        public int CompareTo(object obj)
        {
            Score otherScore = obj as Score;
            if (otherScore != null)
            {
                return this.score.CompareTo(otherScore.score);
            }
            else
            {
                throw new System.ArgumentException("Object is not a Score");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CanvasGameOver.enabled)
        {
            ////GameManager.instance.GetPlayerScore();
            ////GameManager.instance.GetPlayerColor();
            int maxPlayers = GameManager.instance.MAX_PLAYERS;
            //System.Collections.Generic.SortedDictionary<int, string> scores = new System.Collections.Generic.SortedDictionary<int, string>();

            //for (int i = 0; i < maxPlayers; ++i)
            //{
            //    scores[GameManager.instance.GetPlayerScore(i)] = GameManager.instance.GetPlayerColor(i).ToString();
            //}

            //Score1Text.text = scores[ElementAt(scores, 0)].ToString() + ElementAt(scores, 0);
            //Score2Text.text = scores[ElementAt(scores, 1)].ToString() + ElementAt(scores, 1);
            //Score3Text.text = scores[ElementAt(scores, 2)].ToString() + ElementAt(scores, 2);
            //Score4Text.text = scores[ElementAt(scores, 3)].ToString() + ElementAt(scores, 3);

            List<Score> highscores = new List<Score>();

            for (int i = 0; i < maxPlayers; ++i)
            {
                //scores[GameManager.instance.GetPlayerScore(i)] = GameManager.instance.GetPlayerColor(i).ToString();
                highscores.Add(new Score(GameManager.instance.GetPlayerScore(i), GameManager.instance.GetPlayerColor(i)));
                //highscores.Add(new Score(0, ""));

            }
            highscores.Sort();
            highscores.Reverse();
            Score1Text.text = GameManager.instance.GetColorString(highscores[0].playerName) + ": " + highscores[0].score.ToString();
            Score2Text.text = GameManager.instance.GetColorString(highscores[1].playerName) + ": " + highscores[1].score.ToString();
            Score3Text.text = GameManager.instance.GetColorString(highscores[2].playerName) + ": " + highscores[2].score.ToString();
            Score4Text.text = GameManager.instance.GetColorString(highscores[3].playerName) + ": " + highscores[3].score.ToString();

        }

        if (CanvasInGame.enabled)
            TimerText.text = Mathf.CeilToInt(GameManager.instance.GetCurrentPlayerTimer()).ToString();

        GameManager.PlayerColor color = GameManager.instance.GetPlayerColor(GameManager.instance.GetCurrentPlayer());
        //CanvasRenderer rend = playerColorIndicator.GetComponent<CanvasRenderer>();
        CanvasRenderer rend = CanvasInGame.GetComponent<CanvasRenderer>();
        // BUGFIX for intermission canvas null
        if(null == rend)
        {

            rend = CanvasIntermission.GetComponentInChildren<CanvasRenderer>();
        }

        if (null != rend)
        {
            if (color == GameManager.PlayerColor.eColorOne)
            {
                rend.GetMaterial().color = new Color(1f, 0f, 0.3f, 1);
            }
            else if (color == GameManager.PlayerColor.eColorTwo)
            {
                rend.GetMaterial().color = new Color(0.16f, 0.67f, 1f, 1);
            }
            else if (color == GameManager.PlayerColor.eColorThree)
            {
                rend.GetMaterial().color = new Color(0f, 0.89f, 0.21f, 1);
            }
            else if (color == GameManager.PlayerColor.eColorFour)
            {
                rend.GetMaterial().color = new Color(1f, 0.93f, 0.15f, 1);
            }
        }
    }
}
