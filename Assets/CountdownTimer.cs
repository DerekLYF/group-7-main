using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public Text timerText;
    public float countdownTime = 10.0f; // Set the initial countdown time in seconds

    private float currentTime;
    private bool isCountingDown;

    void Start()
    {
        currentTime = countdownTime;
        isCountingDown = true;
    }

    void Update()
    {
        if (isCountingDown)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0.0f)
            {
                currentTime = 0.0f;
                isCountingDown = false;
                OnCountdownFinished();
            }

            UpdateTimerText();
        }
    }

    void UpdateTimerText()
    {
        int seconds = (int)(currentTime % 60);

        timerText.text = $"{seconds:00}";
    }

    void OnCountdownFinished()
    {
        // Do something when the countdown finishes, e.g., load a new scene
        Debug.Log("Countdown finished!");
    }
}