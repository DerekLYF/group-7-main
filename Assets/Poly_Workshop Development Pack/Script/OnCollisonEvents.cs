using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnCollisonEvents : MonoBehaviour
{
    [Tooltip("If this is empty, everything will trigger the events")]
    [SerializeField] List<string> matchTags;
    [SerializeField] UnityEvent<GameObject> onCollisionEnter;
    [SerializeField] UnityEvent<GameObject> onCollisionStay;
    [SerializeField] UnityEvent<GameObject> onCollisionExit;

    private float elapsedTime = 0f;
    private bool isPlayerStaying = false;

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
                    elapsedTime = 0f;
                }
            }
        }
    }

    private IEnumerator EatFood()
    {
        while (isPlayerStaying && elapsedTime < 5f)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        if (isPlayerStaying)
        {
            print("Player has eaten the food");
            onCollisionStay.Invoke(null);
        }
    }
}