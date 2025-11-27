using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;
    public float rotationSpeed = 120f;

    [Header("Camera Look")]
    public Transform cameraTransform;
    public float mouseSensitivity = 300f;

    private float xRotation = 0f;

    private Rigidbody rb;
    private Animator animator;
    private bool isWalking;

    private float VerticalInput;
    private float HorizontalInput;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        if (rb != null)
            rb.interpolation = RigidbodyInterpolation.Interpolate;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // ======== Movement Input ========
        VerticalInput = Input.GetAxis("Vertical");
        HorizontalInput = Input.GetAxis("Horizontal");

        isWalking = Mathf.Abs(VerticalInput) > 0.01f || Mathf.Abs(HorizontalInput) > 0.01f;


        if (animator != null)
            animator.SetBool("isWalking", isWalking);

        // ======== Camera Look ========
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -70f, 70f);

        if (cameraTransform != null)
        {
            cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        }
    }

    private void FixedUpdate()
    {
        if (rb == null) return;

        Vector3 forward = rb.rotation * Vector3.forward * VerticalInput;
        Vector3 right = rb.rotation * Vector3.right * HorizontalInput;

        Vector3 movement = (forward + right).normalized * speed * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + movement);
    }

}
