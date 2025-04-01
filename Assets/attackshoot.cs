using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackshoot : MonoBehaviour
{
    public float speed = 10f; // Speed of attack movement

    // Update is called once per frame
    void Update()
    {
        // Move the attack in the direction of the firePoint's forward direction
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Optional: Destroy attack object after it goes off screen
        if (transform.position.z > 9f) 
        {
            Destroy(gameObject);
        }
    }
}