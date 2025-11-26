using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;
    public float rotationSpeed = 120f;

    private Rigidbody rb;
    private Animator animator;

    private float moveInput;
    private float turnInput;

    // Animator parameter name (create a Bool parameter with this name in your Animator)
    private const string ANIM_IS_WALKING = "isWalking";

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        if (rb != null)
            rb.interpolation = RigidbodyInterpolation.Interpolate;
    }

    private void Update()
    {
        // Read inputs in Update (more responsive)
        moveInput = Input.GetAxis("Vertical");   // W/S or Up/Down
        turnInput = Input.GetAxis("Horizontal"); // A/D or Left/Right

        // Decide walking state (use a small threshold to avoid micro jitter)
        bool isWalking = Mathf.Abs(moveInput) > 0.01f;

        if (animator != null)
        {
            animator.SetBool(ANIM_IS_WALKING, isWalking);
        }
    }

    private void FixedUpdate()
    {
        if (rb == null) return;

        // Use Rigidbody rotation to compute forward direction (keeps things consistent)
        Vector3 forward = rb.rotation * Vector3.forward;
        Vector3 movement = forward * moveInput * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);

        float turnAngle = turnInput * rotationSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turnAngle, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}