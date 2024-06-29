using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Helper script to mark the area, in which the Witch can see the player
public class SusBox : MonoBehaviour
{
    [SerializeField]
    private WitchManager witchManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            witchManager.PlayerEnteredBox(); // Notify the Game Manager
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            witchManager.PlayerExitedBox(); // Notify the Game Manager
        }
    }
}
