using System.Collections;
using UnityEngine;

public class WitchManager : MonoBehaviour
{
    public WitchBehavior witch;
    public GameObject detectionBox;
    public float watchTime = 5f; // Duration for which the witch will watch
    private float currentWatchTime;
    private bool playerInBox;

    private void Start()
    {
        currentWatchTime = watchTime;
    }

    private void Update()
    {
        if (playerInBox)
        {
            currentWatchTime -= Time.deltaTime;
            if (currentWatchTime <= 0f)
            {
                witch.isWatching = false; // Stop watching after the timer ends
                playerInBox = false; // Reset the player in box status
            }
            else
            {
                witch.isWatching = true; // Continue watching
            }
        }
        else
        {
            currentWatchTime = Mathf.Min(currentWatchTime + Time.deltaTime, watchTime); // Recover the timer when the player leaves
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInBox = true; // Player entered the detection box
            Debug.Log("I CAN SEE YOU");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInBox = false; // Player left the detection box
            StartCoroutine(StopWatchingAfterDelay(3f)); // Ensure witch stops watching after 3 seconds
        }
    }

    private IEnumerator StopWatchingAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        witch.isWatching = false;
    }
}
