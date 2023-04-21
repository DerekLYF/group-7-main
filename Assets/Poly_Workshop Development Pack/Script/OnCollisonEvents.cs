using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class OnCollisonEvents : MonoBehaviour
{
    [Tooltip("If this is empty, everything will trigger the events")]
    [SerializeField] List<string> matchTags;
    [SerializeField] UnityEvent<GameObject> onCollisionEnter;
    [SerializeField] UnityEvent<GameObject> onCollisionStay;
    [SerializeField] UnityEvent<GameObject> onCollisionExit;
    [SerializeField] Slider progressBar;
    [SerializeField] Text countdownText; // Manually added field

    private float elapsedTime = 0f;
    private bool isPlayerStaying = false;
    private int foodEaten = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if (matchTags.Count == 0)
        {
            print(collision.collider.name + " On Collision Entered");
            onCollisionEnter.Invoke(null);
        }
        else
        {
            for (int i = 0; i < matchTags.Count; i++)
            {
                if (collision.gameObject.CompareTag(matchTags[i]))
                {
                    print(collision.collider.name + " On Collision Entered");
                    onCollisionEnter.Invoke(null);
                    isPlayerStaying = true;
                    StartCoroutine(EatFood());
                }
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (matchTags.Count == 0)
        {
            print(collision.collider.name + " On Collision Exited");
            onCollisionExit.Invoke(null);
        }
        else
        {
            for (int i = 0; i < matchTags.Count; i++)
            {
                if (collision.gameObject.CompareTag(matchTags[i]))
                {
                    print(collision.collider.name + " On Collision Exited");
                    onCollisionExit.Invoke(null);
                    isPlayerStaying = false;
                    if (countdownText != null)
                    {
                        countdownText.text = "5"; // Reset the countdown timer to 5 seconds
                    }
                }
            }
        }
    }

    private IEnumerator EatFood()
    {
        float remainingTime = 5f;
        while (isPlayerStaying && remainingTime > 0f)
        {
            remainingTime -= Time.deltaTime;
            if (countdownText != null)
            {
                countdownText.text =  Mathf.CeilToInt(remainingTime).ToString();
            }
            yield return null;
        }

        if (isPlayerStaying)
        {
            foodEaten++;
            Debug.Log("Player has eaten " + foodEaten + " food");
            onCollisionStay.Invoke(null);
            if (progressBar != null)
            {
                progressBar.maxValue = 14; // Set the maximum value of the progress bar to 14
                progressBar.value = foodEaten; // Set the value of the progress bar to the number of food eaten
            }
            if (countdownText != null)
            {
                countdownText.text = "5";
            }
        }
    }
}