using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public GameObject intText;
    public bool interactable = true;
    public bool toggle;
    public Animator doorAnim;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            intText.SetActive(true);
            interactable = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            intText.SetActive(false);
            interactable = false;
        }
    }

    void Update()
    {
            if (Input.GetKeyDown(KeyCode.E))
            {
                toggle = !toggle;
                Debug.Log("Toggle State: " + toggle);

                if (toggle == true)
                {
                    doorAnim.ResetTrigger("Close");
                    doorAnim.SetTrigger("Open");
                    Debug.Log("Door is opening");
                }
                else
                {
                    doorAnim.ResetTrigger("Open");
                    doorAnim.SetTrigger("Close");
                    Debug.Log("Door is closing");
                }
                
                intText.SetActive(false);
                interactable = false;
            }
        }
}
