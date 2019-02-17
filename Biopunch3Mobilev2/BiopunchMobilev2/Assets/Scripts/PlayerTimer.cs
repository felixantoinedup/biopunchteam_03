using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTimer : MonoBehaviour
{
    private float startTime = 0.0f;
    private float currentTime = 0.0f;
    private bool stopped = false;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        currentTime = startTime;
    }

    public void StopTimer()
    {
        stopped = true;
    }

    public void StartTimer()
    {
        startTime = Time.time;
        stopped = false;
    }

    public void Reset()
    {
        startTime = Time.time;
        currentTime = startTime;
    }

    public float GetElapsedTime()
    {
        return currentTime - startTime;
    }

    void Update()
    {
        if(!stopped)
        {
            currentTime +=Time.deltaTime;
        }
    }
}