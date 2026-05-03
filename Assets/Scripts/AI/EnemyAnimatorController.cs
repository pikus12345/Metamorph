using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimatorController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animator;

    private void Update()
    {
        float speed = agent.velocity.magnitude;
        animator?.SetFloat("Speed", speed);
    }
}
