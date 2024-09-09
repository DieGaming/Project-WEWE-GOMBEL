using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    public GameObject jumpScare;
    public AudioSource scareSound;
    public Collider collsion;
    public UnityEvent onEnter;
    public UnityEvent onExit;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jumpScare.SetActive(true);
            scareSound.Play();
            collsion.enabled = false;
            onEnter.Invoke();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jumpScare.SetActive(false);
            scareSound.Stop();
            onExit.Invoke();
        }
    }
}
