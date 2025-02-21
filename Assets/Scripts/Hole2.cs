using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole2 : MonoBehaviour
{
    // Set the respawn position in the script
    private Vector3 respawnPosition = new Vector3(41.25f, 4.46999979f, -0.0169999f);

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Move the player to the respawn position
            other.transform.position = respawnPosition;
        }
    }
}
