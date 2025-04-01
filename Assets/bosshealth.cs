using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class bosshealth : MonoBehaviour
{
    public int bighealth = 1500; // Boss's health
    public TextMeshProUGUI bighealthText; // UI Text to display boss health
    
    // Sound variables
    public AudioClip deathSound;
    private AudioSource audioSource;

    void Start()
    {
        UpdateBigHealthDisplay();
        
        // Get or add AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void TakeDamage(int damage)
    {
        bighealth -= damage;
        UpdateBigHealthDisplay();

        if (bighealth <= 0)
        {
            PlayDeathSound();
            Destroy(gameObject, 0.3f); // Slightly longer delay for boss death sounds
        }
    }

    private void PlayDeathSound()
    {
        if (deathSound != null)
        {
            // Method 1: Play at position (works after destruction)
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            
            // Method 2: Using AudioSource component (uncomment if preferred)
            // audioSource.pitch = Random.Range(0.8f, 1.2f); // Epic pitch variation
            // audioSource.PlayOneShot(deathSound);
        }
    }

    private void UpdateBigHealthDisplay()
    {
        if (bighealthText != null)
        {
            bighealthText.text = "Boss Health: " + bighealth.ToString();
        }
    }
}