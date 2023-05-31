using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float moveSpeed = 3f; // Speed at which the enemy moves

    private void Update()
    {
        // Calculate the direction from the enemy to the player
        Vector3 direction = player.position - transform.position;
        direction.Normalize();

        // Move the enemy towards the player
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}