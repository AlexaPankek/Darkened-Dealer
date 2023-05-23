using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 2f;
    public float jumpForce = 5f;
    public float gravity = 9.8f;

    private CharacterController characterController;
    private Camera playerCamera;
    private float verticalRotation = 0f;
    private Vector3 moveDirection;
    private bool isJumping;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Rotation input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Player rotation
        transform.Rotate(Vector3.up, mouseX);
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
        playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);

        // Movement input
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate the movement direction based on input
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        movement = transform.TransformDirection(movement);
        movement *= moveSpeed;

        // Apply gravity
        if (!characterController.isGrounded)
        {
            movement.y -= gravity * Time.deltaTime;
        }

        // Jumping
        if (characterController.isGrounded)
        {
            if (!isJumping && Input.GetButtonDown("Jump"))
            {
                movement.y = jumpForce;
                isJumping = true;
            }
        }
        else
        {
            isJumping = false;
        }

        // Apply movement to the character controller
        characterController.Move(movement * Time.deltaTime);
    }
}