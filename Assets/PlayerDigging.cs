using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDigging : MonoBehaviour
{
    private bool isPlayerInDigZone = false;

    void Update()
    {
        if (isPlayerInDigZone && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Player is digging!");
            Dig();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInDigZone = true;
            ClueUIManager clueUI = FindObjectOfType<ClueUIManager>();
            if (clueUI != null) clueUI.ShowDigPrompt();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInDigZone = false;
            ClueUIManager clueUI = FindObjectOfType<ClueUIManager>();
            if (clueUI != null) clueUI.HideDigPrompt();
        }
    }

    void Dig()
    {
        Debug.Log("Treasure dug!");
        gameObject.SetActive(false);

        GameObject clue = GameObject.Find("ClueText");
        if (clue != null)
        {
            clue.SetActive(false);
        }

        ClueUIManager clueUI = FindObjectOfType<ClueUIManager>();
        if (clueUI != null) clueUI.HideDigPrompt(); // Also hide the prompt after digging
    }
}
