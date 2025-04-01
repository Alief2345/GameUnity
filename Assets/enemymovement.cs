using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymovement : MonoBehaviour
{
    public float speed = 5f; // Speed of the enemy movement
    private float leftBound = -10f; // Left boundary for the enemy to reset its position

    // Start is called before the first frame update
    void Start()
    {
        // Optionally, you can set the initial position of the enemy here
    }

    // Update is called once per frame
    void Update()
    {
        // Move the enemy to the left
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // Check if the enemy has moved past the left boundary
        if (transform.position.x < leftBound)
        {
            // Reset the enemy's position to the right side of the screen
            transform.position = new Vector2(10f, transform.position.y); // Adjust the x value as needed
        }
    }
}