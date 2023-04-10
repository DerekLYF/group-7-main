using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float detectRange = 2f;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform target;

    private bool isActive = false;

    void Update()
    {
        
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            if (direction.magnitude > detectRange)
            {
                isActive = false;
                animator.SetBool("isActive", isActive);
                animator.SetFloat("Speed", moveSpeed);
                transform.LookAt(target);
                transform.position += direction.normalized * moveSpeed * Time.deltaTime;
            }
            else
            {
                isActive = true;
                animator.SetBool("isActive", isActive);
                animator.SetFloat("Speed", 0f);
            }
        }
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    public void ClearTarget()
    {
        target = null;
    }
}