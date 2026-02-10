using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Make sure your player is tagged "Player"
        {
            Debug.Log("Treasure Collected!");        }
    }
}
