using UnityEngine;

public class EnemyCollisionAvoidance : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the enemy collides with any objects
        // You can add specific tags or layers to the objects you want the enemy to avoid
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Calculate the avoidance direction away from the collided object
            Vector3 avoidanceDirection = transform.position - collision.transform.position;
            avoidanceDirection.Normalize();

            // Apply the avoidance direction to avoid the obstacle
            transform.position += avoidanceDirection * Time.deltaTime;
        }
    }
}