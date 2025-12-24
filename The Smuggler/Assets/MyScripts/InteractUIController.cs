using UnityEngine;

public class InteractUIController : MonoBehaviour
{
    [SerializeField] private GameObject interactUI;

    void Awake()
    {
        interactUI.SetActive(false);
    }

    public void Show()
    {
        interactUI.SetActive(true);
    }

    public void Hide()
    {
        interactUI.SetActive(false);
    }
}