using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damageAmount = 10; // Damage dealt by the projectile
    public float speed = 10f; // Speed of the projectile movement

    private Vector2 direction; // Direction of the projectile

    // Method to initialize the projectile's direction and speed
    public void Initialize(Vector2 dir, float projectileSpeed)
    {
        direction = dir;
        speed = projectileSpeed;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
    }



    void Update()
    {
        // Move the projectile in the specified direction
        transform.Translate(direction * speed * Time.deltaTime);

        // Optional: Destroy the projectile after it goes off screen
        if (Mathf.Abs(transform.position.x) > 9f || Mathf.Abs(transform.position.y) > 5f) // Adjust based on your screen size
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            healthspacecraft playerHealth = collider.GetComponent<healthspacecraft>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount); // Apply damage to the player
            }
            Destroy(gameObject); // Destroy the projectile after hitting the player
        }
    }
}