using UnityEngine;
using TMPro;
using System; // Required for Type handling

public class UpdateCollectibleCount : MonoBehaviour
{
    private TextMeshProUGUI collectibleText; // Reference to the TextMeshProUGUI component
    public AudioClip vfxSound; // Assign in Inspector
    private AudioSource audioSource;
    private bool hasPlayed = false; // Flag to check if audio has played

    void Start()
    {
        collectibleText = GetComponent<TextMeshProUGUI>();
        audioSource = gameObject.AddComponent<AudioSource>();
        
        if (collectibleText == null)
        {
            Debug.LogError("UpdateCollectibleCount script requires a TextMeshProUGUI component on the same GameObject.");
            return;
        }
        
        UpdateCollectibleDisplay(); // Initial update on start
    }

    void Update()
    {
        UpdateCollectibleDisplay();
    }

    private void UpdateCollectibleDisplay()
    {
        int totalCollectibles = 0;

        // Check and count objects of type Collectible
        Type collectibleType = Type.GetType("Collectible");
        if (collectibleType != null)
        {
            totalCollectibles += UnityEngine.Object.FindObjectsByType(collectibleType, FindObjectsSortMode.None).Length;
        }

        // Optionally, check and count objects of type Collectible2D as well if needed
        Type collectible2DType = Type.GetType("Collectible2D");
        if (collectible2DType != null)
        {
            totalCollectibles += UnityEngine.Object.FindObjectsByType(collectible2DType, FindObjectsSortMode.None).Length;
        }

        // Update the collectible count display
        collectibleText.text = $"Collectibles remaining: {totalCollectibles}";
        
        // Play VFX sound only once when all collectibles are obtained
        if (totalCollectibles == 0 && vfxSound != null && !hasPlayed)
        {
            audioSource.PlayOneShot(vfxSound);
            hasPlayed = true; // Set flag to true so the sound doesn't play again
        }
    }
}
