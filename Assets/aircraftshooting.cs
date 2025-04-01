using UnityEngine;

public class aircraftshooting : MonoBehaviour
{
    public GameObject attackPrefab;
    public Transform firePoint;
    public float fireRate = 20f;
    private float nextFireTime = 0f;
    
    // Add these for sound
    public AudioClip shootingSound;
    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Add one if it doesn't exist
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot() 
    {
        // Play shooting sound if available
        if (shootingSound != null)
        {
            audioSource.PlayOneShot(shootingSound);
        }

        GameObject attack = Instantiate(attackPrefab, firePoint.position, firePoint.rotation);
        attack.transform.parent = transform;
    }
}