using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnHit : MonoBehaviour
{
    public int damage; // Damage amount
    public int scorePerHit = 10; // Score gained per hit
    private scorespacecraft scoreManager; // Reference to the score manager

    private void Start()
    {
        // Find the score manager in the scene
        scoreManager = FindObjectOfType<scorespacecraft>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collided object is the boss
        if (collision.CompareTag("Boss"))
        {
            Debug.Log("Boss hit detected");
            bosshealth bossHealth = collision.GetComponent<bosshealth>();
            if (bossHealth != null)
            {
                Debug.Log("Boss health component found");
                // Apply damage to boss
                bossHealth.TakeDamage(damage);
                UpdateScore(); // Update score for hitting the boss
                Destroy(gameObject); // Destroy the object that deals damage
            }
            else
            {
                Debug.Log("Boss health component not found");
            }
        }
        // Check if the collided object is an enemy
        else if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Enemy hit detected");
            enemyhealth enemyHealth = collision.GetComponent<enemyhealth>();
            if (enemyHealth != null)
            {
                Debug.Log("Enemy health component found");
                // Apply damage to enemy
                enemyHealth.TakeDamage(damage);
                UpdateScore(); // Update score for hitting the enemy
                Destroy(gameObject); // Destroy the object that deals damage
            }
            else
            {
                Debug.Log("Enemy health component not found");
            }
        }
    }

    // Method to update the score
    private void UpdateScore()
    {
        if (scoreManager != null)
        {
            scoreManager.score += scorePerHit; // Increase score
            scoreManager.UpdateScoreDisplay(); // Update the score display
        }
    }
}