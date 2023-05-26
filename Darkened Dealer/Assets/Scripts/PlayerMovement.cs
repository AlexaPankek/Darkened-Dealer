using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Walk, run, and camera sensitivty values
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float mouseSensitivity = 2f;

    //Camera, character controller, speed, and rotation values
    private CharacterController characterController;
    private Camera playerCamera;
    private float verticalRotation = 0f;
    private float currentSpeed;

    //Stamina Bar
    public float maxStamina = 100f;
    public float staminaConsumptionRate = 10f;
    public float staminaRegenerationRate = 5f;

    private float currentStamina;
    private StaminaBar staminaBar;


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

    
}