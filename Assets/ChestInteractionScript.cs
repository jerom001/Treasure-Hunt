using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteractionScript : MonoBehaviour
{
    private bool isPlayerNear = false;
    private GameObject nearbyChest; // Stores the chest the player is near

    void Update()
    {
        // Check if the player is near a chest and presses "E"
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Opening Chest!");
            OpenChest(nearbyChest);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object the player is near is tagged as "Chest"
        if (other.CompareTag("Chest"))
        {
            isPlayerNear = true;
            nearbyChest = other.gameObject; // Store reference to chest
            Debug.Log("Player is near the chest. Press 'E' to open!");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Chest"))
        {
            isPlayerNear = false;
            nearbyChest = null; // Clear reference when player leaves
        }
    }

    void OpenChest(GameObject chest)
    {
        if (chest != null)
        {
            Debug.Log("Chest Opened!");

            // Deactivate the chest instead of destroying it
            chest.SetActive(false);

            // TODO: Hide the clue here if needed
            GameObject clue = GameObject.Find("ClueText"); // Make sure your clue object is named correctly
            if (clue != null)
            {
                clue.SetActive(false);
            }
        }
        else
        {
            Debug.LogWarning("No chest to open!");
        }
    }
}
