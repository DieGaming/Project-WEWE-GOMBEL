using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public GameObject detectionUI; // Reference to the UI element

    void Start()
    {
        if (detectionUI != null)
        {
            detectionUI.SetActive(false); // Ensure the UI is initially disabled
        }
    }

    public void ShowDetectionUI()
    {
        if (detectionUI != null)
        {
            detectionUI.SetActive(true); // Enable the UI element
        }
    }

    public void HideDetectionUI()
    {
        if (detectionUI != null)
        {
            detectionUI.SetActive(false); // Disable the UI element
        }
    }
}
