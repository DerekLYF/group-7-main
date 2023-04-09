using UnityEngine;
using UnityEngine.AI;

public class FemaleCharacterController : MonoBehaviour
{
    public GameObject destinationPoint;
    public float walkSpeed = 1.0f;

    private Animator animator;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();

        navMeshAgent.speed = walkSpeed;
        navMeshAgent.SetDestination(destinationPoint.transform.position);
        animator.SetFloat("Speed", walkSpeed);
    }

    void Update()
    {
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            animator.SetFloat("Speed", 0);
        }
    }
}