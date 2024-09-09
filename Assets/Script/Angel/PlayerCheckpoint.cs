using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{
    public GameObject door;
    Vector3 spawnPoint;

    void Start()
    {
        spawnPoint = gameObject.transform.position;
    }

    void Update()
    {
        if(gameObject.transform.position.y < -10)
        {
            gameObject.transform.position = spawnPoint;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Checkpoint"))
        {
            spawnPoint = door.transform.position;
        }
    }
}
