using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WitchManager : MonoBehaviour
{
    [SerializeField]
    private WitchBehavior witch;
    [SerializeField]
    private GameObject detectionBox;
    private bool playerInBox;
    private float _initialSusMeter = 10f;
    private float susMeter;
    private float calmDownMeter = 5f;

    [SerializeField]
    private RawImage susMeterOverlay;
    [SerializeField]
    private AnimationCurve susAlphaCurve;

    private void Start()
    {
        susMeter = _initialSusMeter;
    }

    private void Update()
    {
        if (playerInBox)
        {
           if(witch.currentWitchState == 4)
            {
                witch.isWatching = true; // Continue watching
               // Debug.Log("Witch is watching");
                susMeter -= Time.deltaTime;
                if (susMeter <= 0)
                {
                    GameManager.instance.LoadLoseScene();
                }
            }
          
            
        }
        else if (!playerInBox)
        {
            if(susMeter <= _initialSusMeter){susMeter += Time.deltaTime*calmDownMeter;}
        }
        UpdateSusMeterOverlay();
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

    private void UpdateSusMeterOverlay()
    {
        var progressT = 1 - (susMeter / _initialSusMeter);
        float alpha = susAlphaCurve.Evaluate(progressT);
        Color color = susMeterOverlay.color;
        color.a = alpha;
        susMeterOverlay.color = color;
    }
}