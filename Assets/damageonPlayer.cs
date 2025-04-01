using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageonPlayer : MonoBehaviour
{
    public int damageAmount = 10; // Amount of damage to deal to the player
    public float damageCooldown = 1f; // Time between damage applications
    private bool canDamage = true; // Flag to check if the enemy can deal damage

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if the collided object is the player
        if (collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player collided with enemy");
            if (canDamage)
            {
                // Apply damage to the player
                healthspacecraft playerHealth = collider.gameObject.GetComponent<healthspacecraft>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damageAmount); // Call the method to apply damage
                    StartCoroutine(DamageCooldown()); // Start cooldown to prevent multiple hits
                }
            }
        }
    }

    // Coroutine to handle damage cooldown
    private IEnumerator DamageCooldown()
    {
        canDamage = false; // Set flag to false to prevent further damage
        yield return new WaitForSeconds(damageCooldown); // Wait for the cooldown period
        canDamage = true; // Reset flag to allow damage again
    }
}