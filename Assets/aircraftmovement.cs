using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftMovement : MonoBehaviour
{
    public float moveSpeed = 15f; // Speed of the aircraft movement

    // Update is called once per frame
    void Update()
    {
        // Get input from the user using arrow keys for left/right and up/down movement
        float moveHorizontal = Input.GetAxis("Horizontal"); // Left/Right Arrow keys
        float moveVertical = Input.GetAxis("Vertical"); // Up/Down Arrow keys (W/S or Up/Down Arrow keys)

        // Create a movement vector
        // moveHorizontal for left/right, moveVertical for up/down
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0) * moveSpeed * Time.deltaTime;

        // Move the aircraft
        transform.Translate(movement);
    }
}