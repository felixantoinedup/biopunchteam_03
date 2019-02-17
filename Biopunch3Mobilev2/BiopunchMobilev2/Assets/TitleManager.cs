using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public string SceneToLoad = "Game";
    // Start is called before the first frame update
    void Start()
    {
    }

    public void PushStartGame()
    {
        Debug.Log("sceneName to load: " + SceneToLoad);
        SceneManager.LoadScene(SceneToLoad);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
