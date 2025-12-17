using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody), typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    public float mouseSensitivity = 300f;
    public Transform cameraRoot;
    public float maxLookAngle = 80f;

    private float mouseX;
    private float mouseY;
    private float xRotation = 0f;


    private Rigidbody rb;
    private Animator animator;
    private Vector3 inputDirection;

    private bool isMazeScene;

    public float footstepInterval = 2.0f;
    private float footstepTimer;



    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        rb.freezeRotation = true;
        rb.interpolation = RigidbodyInterpolation.Interpolate;

        Cursor.lockState = CursorLockMode.Locked;
        isMazeScene = SceneManager.GetActiveScene().name == "MazeScene";

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
        if (inputDirection.sqrMagnitude > 0.01f)
        {
            Vector3 moveDir = transform.TransformDirection(inputDirection) * speed;
            rb.MovePosition(rb.position + moveDir * Time.fixedDeltaTime);

            footstepTimer -= Time.fixedDeltaTime;
            if (footstepTimer <= 0f)
            {
                PlayFootstepSound();
                footstepTimer = footstepInterval;
            }
        }
        else
        {
            footstepTimer = 0f;
        }

        Quaternion deltaRotation = Quaternion.Euler(0f, mouseX, 0f);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }


    public void PlayFootstepSound()
    {
        if (isMazeScene)
            AudioManager.instance.PlayWalkingOnSnowSound();
        else
            AudioManager.instance.PlayWalkingSound();
    }
}
