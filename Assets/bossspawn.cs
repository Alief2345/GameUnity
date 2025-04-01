using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossspawn : MonoBehaviour
{
    public GameObject bossPrefab; // Reference to the boss prefab
    public Transform spawnPoint;  // Position where the boss will spawn

    // Method to spawn the boss
    public void SpawnBoss()
    {
        if (bossPrefab != null && spawnPoint != null)
        {
            Instantiate(bossPrefab, spawnPoint.position, spawnPoint.rotation);
            Debug.Log("Boss spawned!");
        }
        else
        {
            Debug.LogError("Boss prefab or spawn point not set!");
        }
    }
}