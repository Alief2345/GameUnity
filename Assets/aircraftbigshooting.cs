using UnityEngine;

public class aircraftbigshooting : MonoBehaviour
{
    public GameObject bigAttackPrefab;
    public Transform firePoint;
    public float fireRate = 11f;
    private float nextFireTime = 0f;
    
    // Add these for sound
    public AudioClip bigShootingSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            ShootBigAttack();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void ShootBigAttack()
    {
        // Play big shooting sound if available
        if (bigShootingSound != null)
        {
            audioSource.PlayOneShot(bigShootingSound);
        }

        GameObject bigAttack = Instantiate(bigAttackPrefab, firePoint.position, firePoint.rotation);
        bigAttack.transform.parent = transform;
    }
}