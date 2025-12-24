using UnityEngine;
using UnityEngine.UI;

public class InteractUI : MonoBehaviour
{
    [Header("UI Settings")]
    public Image interactionImage;  // Assign the unique image for this object
    public KeyCode interactKey = KeyCode.E;

    private bool playerNearby = false;  // Is the player close enough to interact?
    private bool isVisible = false;

    private void Start()
    {
        if (interactionImage != null)
            interactionImage.gameObject.SetActive(false); // Hide at start
    }

    private void Update()
    {
        if (playerNearby && Input.GetKeyDown(interactKey))
        {
            if (interactionImage != null)
            {
                isVisible = !isVisible; // Toggle visibility
                interactionImage.gameObject.SetActive(isVisible);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("schange"))
            playerNearby = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("schange"))
        {
            playerNearby = false;
            isVisible = false;
            if (interactionImage != null)
                interactionImage.gameObject.SetActive(false); // Hide when leaving
        }
    }
}
