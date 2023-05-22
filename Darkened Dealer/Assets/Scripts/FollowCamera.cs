using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;  // Reference to the player's transform
    public Vector3 offset = new Vector3(0f, 5f, 0f);  // Offset from the player
    public float rotationSpeed = 3f;  // Mouse rotation speed

    private float mouseX;  // Mouse X input

    void LateUpdate() 
    {
        if (target != null)
        {
            // Rotate the player and camera based on mouse input
            mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
            Quaternion rotation = Quaternion.Euler(0f, mouseX, 0f);
            target.rotation = rotation;

            // Update the camera position based on the player's position and rotation
            Vector3 rotatedOffset = rotation * offset;
            transform.position = target.position + rotatedOffset;
            transform.LookAt(target.position);
        }
    }
}