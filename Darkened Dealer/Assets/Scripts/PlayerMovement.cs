using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Walk, run, and camera sensitivity values
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float mouseSensitivity = 2f;

    // Camera, character controller, speed, and rotation values
    private CharacterController characterController;
    private Camera playerCamera;
    private float verticalRotation = 0f;
    private float currentSpeed;

     private bool allowRotation = true;

    // Stamina Bar
    public float maxStamina = 100f;
    public float staminaConsumptionRate = 10f;
    public float staminaRegenerationRate = 5f;

    private float currentStamina;
    private StaminaBar staminaBar;

    // Pause functionality
    private bool isPaused;

     public float interactRange = 2f; // The range at which the player can interact with objects
    private DoorController currentDoor; // Reference to the currently interactable door

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        currentSpeed = walkSpeed;

        staminaBar = FindObjectOfType<StaminaBar>();
        staminaBar.SetMaxStamina(maxStamina);
        currentStamina = maxStamina;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentDoor != null)
            {
                currentDoor.OpenDoor();
            }
        }
    }

    public void AllowRotation(bool allow)
    {
        allowRotation = allow;
    }
    private void Update()
    {
        if (!allowRotation)
        {
            return; // Skip rotation update if rotation is disallowed
        }
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
        movement *= currentSpeed;

        // Apply movement to the character controller
        characterController.Move(movement * Time.deltaTime);

        // Check for sprinting
        if (Input.GetKey(KeyCode.LeftShift) && currentStamina > 0)
        {
            currentSpeed = runSpeed;
            currentStamina -= staminaConsumptionRate * Time.deltaTime;
            staminaBar.SetStamina(currentStamina);
        }
        else
        {
            currentSpeed = walkSpeed;
            if (currentStamina < maxStamina)
            {
                currentStamina += staminaRegenerationRate * Time.deltaTime;
                staminaBar.SetStamina(currentStamina);
            }
        }
        currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            // Check if the door is within interact range
            float distance = Vector3.Distance(transform.position, other.transform.position);
            if (distance <= interactRange)
            {
                currentDoor = other.GetComponent<DoorController>();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            currentDoor = null;
        }
    }
}