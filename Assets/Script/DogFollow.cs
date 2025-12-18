using UnityEngine;
using UnityEngine.AI;

public class DogFollow : MonoBehaviour
{
    public Transform player;
    public float followDistance = 1.5f;
    public float runSpeed = 5f;
    public float walkSpeed = 2f;
    bool canFollow = true;
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
        if (!canFollow)
        {
            // FORCE idle + wiggle only
            animator.SetFloat("Speed", 0f);
            animator.SetBool("Wiggle", true);
            return;
        }

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

        float speed = agent.velocity.magnitude;
        animator.SetFloat("Speed", speed);

        // Tail wiggle logic (only when following)
        if (speed < 0.1f)
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


    public void StopFollowing()
    {
        canFollow = false;

        agent.isStopped = true;
        agent.ResetPath();
        agent.velocity = Vector3.zero;

        animator.SetFloat("Speed", 0f);
        animator.SetBool("Wiggle", true);
    }
}