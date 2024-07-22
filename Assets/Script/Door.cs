using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float openSpeed = 2f; // Speed at which the door opens
    public Vector3 openRotation = new Vector3(0, 90, 0); // Rotation to open the door (for example, 90 degrees around Y-axis)

    private bool isOpening = false;
    private Quaternion initialRotation;
    private Quaternion targetRotation;

    private void Start()
    {
        initialRotation = transform.rotation;
        targetRotation = Quaternion.Euler(initialRotation.eulerAngles + openRotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player entered the trigger zone
            isOpening = true;
        }
    }

    private void Update()
    {
        if (isOpening)
        {
            // Open the door gradually
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, openSpeed * Time.deltaTime);

            // Check if door is fully opened
            if (Quaternion.Angle(transform.rotation, targetRotation) < 1f)
            {
                isOpening = false; // Stop opening
            }
        }
    }
}
