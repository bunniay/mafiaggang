using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    public float gravity = -9.81f;

    [Header("Mouse Look Settings")]
    public float mouseSensitivity = 2f;       // Controls how sensitive the mouse movement is
    public Transform playerCamera;            // Assign your main camera here
    private float xRotation = 0f;             // Tracks up/down rotation of the head (camera)

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        if (controller == null)
        {
            Debug.LogError("CharacterController not found on this GameObject.");
            enabled = false;
            return;
        }

        // Lock and hide cursor so it doesn’t move outside the game window
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandleMovement();
        HandleLook();
    }

    void HandleMovement()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = 0f;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * horizontalInput + transform.forward * verticalInput;
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
            playerVelocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);

        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    void HandleLook()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Horizontal rotation (turn body left/right)
        transform.Rotate(Vector3.up * mouseX);

        // Vertical rotation (look up/down)
        xRotation -= mouseY;                                // Invert so up is up
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);      // Limit head tilt
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}