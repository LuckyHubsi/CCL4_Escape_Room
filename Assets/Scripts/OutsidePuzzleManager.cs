using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsidePuzzleManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] gameObjects = new GameObject[8];

    // Update is called once per frame
    private void Update()
    {
        // Check if all GameObjects are active
        if (AllGameObjectsActive())
        {
            // Call the desired function
            OnAllGameObjectsActive();
        }
    }

    // Method to check if all GameObjects are active
    private bool AllGameObjectsActive()
    {
        foreach (GameObject obj in gameObjects)
        {
            if (!obj.activeSelf)
            {
                return false;
            }
        }
        return true;
    }

    // Function to call when all GameObjects are active
    private void OnAllGameObjectsActive()
    {
        Debug.Log("All GameObjects are active!");
        // Place your desired function call here
    }
}
