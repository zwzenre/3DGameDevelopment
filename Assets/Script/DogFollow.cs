using UnityEngine;
using UnityEngine.AI;

public class DogFollow : MonoBehaviour
{
    public Transform player;
    public float followDistance = 1.5f;
    public float runSpeed = 5f;
    public float walkSpeed = 2f;

    private NavMeshAgent agent;
    private Animator animator;
    private float wiggleTimer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        agent.speed = walkSpeed;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > followDistance)
        {
            agent.SetDestination(player.position);

            agent.speed = distance > 4f ? runSpeed : walkSpeed;
        }
        else
        {
            agent.ResetPath();
        }

        // Speed → animation
        animator.SetFloat("Speed", agent.velocity.magnitude);

        // Random tail wiggle when idle
        if (agent.velocity.magnitude < 0.1f)
        {
            wiggleTimer += Time.deltaTime;

            if (wiggleTimer > Random.Range(3f, 6f))
            {
                animator.SetBool("Wiggle", true);
                wiggleTimer = 0f;
            }
        }
        else
        {
            animator.SetBool("Wiggle", false);
            wiggleTimer = 0f;
        }
    }
}