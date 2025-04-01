using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigattackshoot : MonoBehaviour
{
    public float speed = 10f; // Speed of big attack movement

    // Update is called once per frame
    void Update()
    {
        // Move the big attack in the forward direction
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Optional: Destroy big attack object after it goes off screen
        if (transform.position.z > 9f) 
        {
            Destroy(gameObject);
        }
    }
}
