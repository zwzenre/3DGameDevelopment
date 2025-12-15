using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;

    [Header("Camera Look")]
    public float mouseSensitivity = 300f;
    public Transform cameraRoot;
    public float maxLookAngle = 80f;

    private float mouseX;
    private float mouseY;
    private float xRotation = 0f;


    private Rigidbody rb;
    private Animator animator;
    private Vector3 inputDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        rb.freezeRotation = true;
        rb.interpolation = RigidbodyInterpolation.Interpolate;

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");

        inputDirection = new Vector3(horizontal, 0f, vertical).normalized;

        animator.SetBool("isWalking", inputDirection.magnitude > 0.1f);

        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -maxLookAngle, maxLookAngle);

        cameraRoot.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

    }

    private void FixedUpdate()
    {
        // ======== Movement ========
        if (inputDirection.sqrMagnitude > 0.01f)
        {
            Vector3 moveDir = transform.TransformDirection(inputDirection) * speed;
            rb.MovePosition(rb.position + moveDir * Time.fixedDeltaTime);
        }

        // ======== Rotation ========
        Quaternion deltaRotation = Quaternion.Euler(0f, mouseX, 0f);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
