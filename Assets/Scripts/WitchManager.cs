using System.Collections;
using UnityEngine;

public class WitchManager : MonoBehaviour
{
    public WitchBehavior witch;
    public GameObject detectionBox;
    private bool playerInBox;

    private void Update()
    {
        if (playerInBox)
        {
          
           witch.isWatching = true; // Continue watching
           Debug.Log("Witch is watching");
            
        }
       
    }

    public void PlayerEnteredBox()
    {
        playerInBox = true; // Player entered the detection box
        Debug.Log("I CAN SEE YOU");
    }
    public void PlayerExitedBox()
    {
        playerInBox = false; // Player left the detection box
        StartCoroutine(StopWatchingAfterDelay(3f)); // Ensure witch stops watching after 3 seconds
        Debug.Log("I CANNOT SEE YOU");
    }


    private IEnumerator StopWatchingAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        witch.isWatching = false;
    }
}
