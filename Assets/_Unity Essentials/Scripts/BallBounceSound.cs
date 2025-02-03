using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BallBounceSound : MonoBehaviour
{
    public AudioClip bounceSound; // Assign in Inspector
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (bounceSound != null)
        {
            audioSource.clip = bounceSound;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (bounceSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(bounceSound);
        }
    }
}
