using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroductionDemo : MonoBehaviour
{
    // you change the name of the "yourButton" title
    public Button yourButton;
    public string sceneName;

    void Start()
    {
        yourButton.onClick.AddListener(ChangeScene);
    }

    //please insert the demo scene and replace "sceneName" name
    void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
