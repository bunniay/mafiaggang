using UnityEngine;

public class SceneTrigger : MonoBehaviour
{
    public string sceneToLoad; // The name of the scene to switch to

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("schange")) // Make sure your player has the tag "Player"
        {
            FadeController.Instance.FadeOut(sceneToLoad); // Call fade out
        }
    }
}