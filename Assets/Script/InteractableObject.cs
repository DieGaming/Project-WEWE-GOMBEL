using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        // Disable or destroy the object
        // Option 1: Disable the object
        gameObject.SetActive(false);

        // Option 2: Destroy the object (uncomment to use)
        // Destroy(gameObject);
    }
}
