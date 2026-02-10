using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureDetection : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player; // Reference to the player GameObject
    public float detectionRadius = 5f; // Adjust based on your needs

    void Start()
    {
        // Automatically find the player by tag (make sure the player has the "Player" tag)
        player = GameObject.FindWithTag("Player");
    }

    void OnTriggerStay(Collider other)
    {
        // Check if the object inside the collider is the player
        if (other.CompareTag("Player"))
        {
            // Check if the player is within the detection radius and their Y position is valid
            float distance = Vector3.Distance(player.transform.position, transform.position);
            if (distance <= detectionRadius && player.transform.position.y >= transform.position.y)
            {
                Debug.Log("Player is inside the digspot area!");
                // You can place additional logic here, like triggering the treasure spawn or giving clues
            }
        }
    }
}
