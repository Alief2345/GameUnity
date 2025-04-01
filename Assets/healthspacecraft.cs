using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import TextMeshPro namespace

public class healthspacecraft : MonoBehaviour
{
    public int health = 1000; // Player's health
    public TextMeshProUGUI healthText; // UI Text to display player's health

    // Start is called before the first frame update
    void Start()
    {
        UpdateHealthDisplay(); // Update health display
    }

    // Method to apply damage to the player
    public void TakeDamage(int damage)
    {
        Debug.Log("Player taking damage: " + damage);
        health -= damage; // Reduce health by damage amount
        UpdateHealthDisplay(); // Update health display

        if (health <= 0)
        {
            Debug.Log("Player defeated");
            // Handle player defeat (e.g., restart game, show game over screen, etc.)
            // You can also disable the player or trigger a game over state here
            Destroy(gameObject);
        }
    }

    // Update the health display
    private void UpdateHealthDisplay()
    {
        healthText.text = "Health: " + health.ToString();
    }
}