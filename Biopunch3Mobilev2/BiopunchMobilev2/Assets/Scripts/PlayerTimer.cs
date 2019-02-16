using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTimer : MonoBehaviour
{
    private float startTime = 0.0f;
    private float currentTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    public void Reset()
    {
        startTime = Time.time;
    }

    public float GetElapsedTime()
    {
        return currentTime - startTime;
    }

    void Update()
    {
        currentTime +=Time.deltaTime;
    }
}