using System.Collections;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class DoorController : MonoBehaviour, IInteractable
{
    public Transform doorTransform; // The transform of the door to rotate
    public float openAngle = 90f; // The angle to open the door to
    public float openSpeed = 2f; // The speed at which the door opens
    public bool isOpen = false; // The current state of the door

    private Quaternion closedRotation;
    private Quaternion openRotation;

    private void Start()
    {
        closedRotation = doorTransform.localRotation;
        openRotation = closedRotation * Quaternion.Euler(0f, openAngle, 0f);
    }

    public void Interact()
    {
        if (isOpen)
        {
            StartCoroutine(CloseDoor());
        }
        else
        {
            StartCoroutine(OpenDoor());
        }
    }

    private IEnumerator OpenDoor()
    {
        isOpen = true;
        float time = 0f;
        while (time < 1f)
        {
            time += Time.deltaTime * openSpeed;
            doorTransform.localRotation = Quaternion.Slerp(closedRotation, openRotation, time);
            yield return null;
        }
    }

    private IEnumerator CloseDoor()
    {
        isOpen = false;
        float time = 0f;
        while (time < 1f)
        {
            time += Time.deltaTime * openSpeed;
            doorTransform.localRotation = Quaternion.Slerp(openRotation, closedRotation, time);
            yield return null;
        }
    }
}
