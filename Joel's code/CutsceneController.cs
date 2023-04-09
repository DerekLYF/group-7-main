using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public float cutsceneDuration = 10f;
    public string gameplaySceneName = "Gameplay";

    private float timer;

    void Start()
    {
        timer = cutsceneDuration;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            SceneManager.LoadScene(gameplaySceneName);
        }
    }
}

//This script will transition to the gameplay scene after a specified duration (in seconds).
