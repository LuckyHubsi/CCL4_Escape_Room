using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Helper script to move the player to the position of the object where the script is on (used after scene change to move the player to a specific location)
public class MovePlayerToPosition : MonoBehaviour
{
    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = gameObject.transform.position;
        DisableAllOutlines();
    }

    private void DisableAllOutlines()
    {
        Outline[] outlines = FindObjectsOfType<Outline>();
        foreach (Outline outline in outlines)
        {
            outline.enabled = false;
        }
    }
}
