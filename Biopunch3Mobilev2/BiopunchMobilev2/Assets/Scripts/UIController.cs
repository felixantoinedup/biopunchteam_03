using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text TimerText;
    public Image playerColorIndicator;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        TimerText.text = Mathf.CeilToInt(GameManager.instance.GetCurrentPlayerTimer()).ToString();
        GameManager.PlayerColor color = GameManager.instance.GetPlayerColor(GameManager.instance.GetCurrentPlayer());
        CanvasRenderer rend = playerColorIndicator.GetComponent<CanvasRenderer>();

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
