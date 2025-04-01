using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class enemyhealth : MonoBehaviour
{
    public int health = 100;
    public TextMeshProUGUI healthText;
    public GameObject boss; // Reference to the boss character
    
    // Sound effect variables
    public AudioClip deathSound;
    private AudioSource audioSource;

    void Start()
    {
        UpdateEnemyHealthDisplay();
        
        // Get or add AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Taking damage: " + damage);
        health -= damage;
        UpdateEnemyHealthDisplay();

        if (health <= 0)
        {
            Debug.Log("Enemy destroyed");
            PlayDeathSound();
            Destroy(gameObject, 0.2f); // Small delay to allow sound to play
            StartBossMovement();
        }
    }

    private void PlayDeathSound()
    {
        if (deathSound != null && audioSource != null)
        {
            // Play sound at the enemy's position (works even after destruction)
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            
            // Alternative if you want to use the AudioSource component:
            // audioSource.pitch = Random.Range(0.9f, 1.1f);
            // audioSource.PlayOneShot(deathSound);
        }
    }

    private void StartBossMovement()
    {
        if (boss != null)
        {
            boss.GetComponent<bossmovement>().StartMoving();
        }
    }

    private void UpdateEnemyHealthDisplay()
    {
        healthText.text = "Enemy Health: " + health.ToString();
    }
}