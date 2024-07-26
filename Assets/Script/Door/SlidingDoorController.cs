using System.Collections;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class SlidingDoorController : MonoBehaviour, IInteractable
{
    public Transform doorTransform; // The transform of the door to move
    public Vector3 openPositionOffset = new Vector3(0f, 0f, 3f); // The offset for the open position
    public float openSpeed = 2f; // The speed at which the door opens and closes
    public bool isOpen = false; // The current state of the door

    private Vector3 closedPosition;
    private Vector3 openPosition;

    private void Start()
    {
        closedPosition = doorTransform.localPosition;
        openPosition = closedPosition + openPositionOffset;
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
            doorTransform.localPosition = Vector3.Lerp(closedPosition, openPosition, time);
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
            doorTransform.localPosition = Vector3.Lerp(openPosition, closedPosition, time);
            yield return null;
        }
    }
}
