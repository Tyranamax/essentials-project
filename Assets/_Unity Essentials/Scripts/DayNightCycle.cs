using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Header("Day Length Settings")]
    [Tooltip("Duration of a full day in seconds.")]
    public float dayDuration = 120f; // Default to 2 minutes for a full day

    private float rotationSpeed;

    void Start()
    {
        // Calculate the rotation speed in degrees per second
        rotationSpeed = 360f / dayDuration;
    }

    void Update()
    {
        // Rotate the light around the X-axis
        transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
    }
}

