using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossmovement : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed of the boss movement
    private bool isMoving = false; // Flag to check if the boss should move
    public float resetPositionX = 10f; // X position to reset the boss
    public float offScreenX = -10f; // X position to consider the boss off-screen

    // Start is called before the first frame update
    void Start()
    {
        // The boss should not start moving until the enemy is defeated
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            MoveBoss();
        }
    }

    // Method to start moving the boss
    public void StartMoving()
    {
        isMoving = true; // Set the flag to true to start moving
    }

    // Method to move the boss from right to left
    private void MoveBoss()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime); // Move left

        // Check if the boss has moved off-screen
        if (transform.position.x < offScreenX)
        {
            ResetBossPosition();
        }
    }

    // Method to reset the boss's position
    private void ResetBossPosition()
    {
        // Check if the boss is still alive
        if (GetComponent<bosshealth>().bighealth > 0)
        {
            transform.position = new Vector2(resetPositionX, transform.position.y);
        }
    }
}