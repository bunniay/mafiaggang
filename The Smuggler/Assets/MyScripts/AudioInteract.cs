using UnityEngine;

public class AudioInteract3D : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private InteractUIController uiController;
    [SerializeField] private KeyCode interactKey = KeyCode.E;

    private bool playerInRange;

    void Update()
    {
        if (!playerInRange) return;

        if (Input.GetKeyDown(interactKey))
        {
            if (audioSource.isPlaying)
                audioSource.Stop();
            else
                audioSource.Play();
        }

        // Show UI only when audio is not playing
        if (audioSource.isPlaying)
            uiController.Hide();
        else
            uiController.Show();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("schange"))
        {
            playerInRange = true;
            uiController.Show();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("schange"))
        {
            playerInRange = false;
            uiController.Hide();
        }
    }
}