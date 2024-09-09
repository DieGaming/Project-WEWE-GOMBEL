using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractItem : MonoBehaviour
{
    public GameObject interactUI;

    void Update()
    {
        // Perform a raycast from the camera to the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Check if the raycast hits an object
        if (Physics.Raycast(ray, out hit))
        {
            // Check if the hit object is the one we want to interact with
            if (hit.transform.CompareTag("Item"))
            {
                // Activate the UI
                interactUI.SetActive(true);
            }
            else
            {
                // Deactivate the UI if the ray is not hitting the object
                interactUI.SetActive(false);
            }
        }
        else
        {
            // Deactivate the UI if the ray is not hitting anything
            interactUI.SetActive(false);
        }
    }

}
