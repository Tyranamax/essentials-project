using UnityEngine;

[RequireComponent(typeof(AudioSource), typeof(Rigidbody))]
public class BlockCollisionSound : MonoBehaviour
{
    public AudioClip collisionSound; // Assign in Inspector
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (collisionSound != null)
        {
            audioSource.clip = collisionSound;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collisionSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(collisionSound);
        }
    }
}