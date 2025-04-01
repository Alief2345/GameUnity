using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossattack : MonoBehaviour
{
    public GameObject projectilePrefab; // Reference to the projectile prefab
    public Transform firePoint; // The point from where the projectile will be fired
    public float attackRange = 10f; // Range within which the boss can detect the player
    public float attackCooldown = 2f; // Time between attacks
    private bool canAttack = true; // Flag to check if the boss can attack

    void Update()
    {
        DetectPlayer();
    }

    private void DetectPlayer()
    {
        // Check for player within range
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, attackRange);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player") && canAttack)
            {
                ShootProjectile(hitCollider.transform.position);
                break; // Exit the loop after detecting the player
            }
        }
    }

    private void ShootProjectile(Vector2 targetPosition)
    {
        if(projectilePrefab == null || firePoint == null)
        {
            Debug.LogError("Projectile prefab or firepoint not assigned");
            return;
        }
        
        // Instantiate the projectile
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        
        // Calculate direction to the player
        Vector2 direction = (targetPosition - (Vector2)firePoint.position).normalized;
        
        // Set the projectile's speed and direction
        projectile.GetComponent<Projectile>().Initialize(direction, 10f); // Pass the direction and speed
        StartCoroutine(AttackCooldown());
    }

    private IEnumerator AttackCooldown()
    {
        canAttack = false; // Prevent further attacks
        yield return new WaitForSeconds(attackCooldown); // Wait for cooldown period
        canAttack = true; // Allow attacking again
    }
}