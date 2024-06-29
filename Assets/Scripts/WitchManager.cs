using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WitchManager : MonoBehaviour
{
    public static WitchManager instance;

    [SerializeField]
    private WitchBehavior witch;
    [SerializeField]
    private GameObject detectionBox;

    public bool playerInBox;

    private float _initialSusMeter = 10f;
    private float _susMeter;
    private float _calmDownMeter = 5f;

    [SerializeField]
    private RawImage susMeterOverlay;
    [SerializeField]
    private AnimationCurve susAlphaCurve;

    [SerializeField]
    private AK.Wwise.RTPC _susVolumeRTPC;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        _susMeter = _initialSusMeter;
        _susVolumeRTPC.SetGlobalValue(0);
    }

    private void Update()
    {
        if (playerInBox)
        {
           if(witch.currentWitchState == 4 && ProgressionManager.instance.puzzleOneSolved)
            {
                witch.isWatching = true; // Continue watching
                _susMeter -= Time.deltaTime;
                _susVolumeRTPC.SetGlobalValue(Mathf.Round(100 - (_susMeter / _initialSusMeter * 100)));
                if (_susMeter <= 0)
                {
                    GameManager.instance.LoadLoseScene();
                }
            }
          
            
        }
        else if (!playerInBox)
        {
            if(_susMeter <= _initialSusMeter){_susMeter += Time.deltaTime*_calmDownMeter;}
            _susVolumeRTPC.SetGlobalValue(Mathf.Round(100 - (_susMeter / _initialSusMeter * 100)));
        }
        else
        {
            _susMeter = _initialSusMeter;
        }
        UpdateSusMeterOverlay();
    }

    public void PlayerEnteredBox()
    {
        playerInBox = true; // Player entered the detection box
    }
    public void PlayerExitedBox()
    {
        playerInBox = false; // Player left the detection box
        StartCoroutine(StopWatchingAfterDelay(3f)); // Ensure witch stops watching after 3 seconds
    }


    private IEnumerator StopWatchingAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        witch.isWatching = false;
    }

    private void UpdateSusMeterOverlay()
    {
        var progressT = 1 - (_susMeter / _initialSusMeter);
        float alpha = susAlphaCurve.Evaluate(progressT);
        Color color = susMeterOverlay.color;
        color.a = alpha;
        susMeterOverlay.color = color;
    }

}
