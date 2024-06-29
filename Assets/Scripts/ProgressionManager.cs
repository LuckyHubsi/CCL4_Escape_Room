using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Helper script to keep track of the current progression of the level/player
public class ProgressionManager : MonoBehaviour
{
    public static ProgressionManager instance;

    #region Barrier References
    [SerializeField]
    private GameObject barrierWindow;
    [SerializeField]
    private GameObject barrierDoor;
    [SerializeField]
    private GameObject barrierFire;
    [SerializeField]
    private GameObject barrierMirror;
    #endregion

    public bool puzzleOneSolved = false;
    public bool puzzleTwoSolved = false;
    public bool puzzleThreeSolved = false;

    //Wwise
    private bool puzzleThreeAudioBool = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        UpdateBarriers();
    }

    public void SolvePuzzleOne()
    {
        puzzleOneSolved = true;
        UpdateBarriers();
    }

    public void SolvePuzzleTwo()
    {
        puzzleTwoSolved = true;
        UpdateBarriers();
    }

    public void SolvePuzzleThree()
    {
        puzzleThreeSolved = true;
        UpdateBarriers();
    }

    // Method to update the barriers based on the current progress of the level/player
    private void UpdateBarriers()
    {
        if (puzzleOneSolved)
        {
            barrierWindow.SetActive(false);
            barrierMirror.SetActive(false);
        }
        if (puzzleTwoSolved)
        {
            barrierDoor.SetActive(false);

            //Wwise
            AkSoundEngine.PostEvent("Stop_Magic_Barrier_Door", barrierDoor);
        }
        if (puzzleThreeSolved && !puzzleThreeAudioBool)
        {
            //Wwise
            AkSoundEngine.SetSwitch("PlayerInteractSwitch", "Using_Water", barrierFire);
            AkSoundEngine.PostEvent("Play_Player_Interact", barrierFire);
            AkSoundEngine.PostEvent("Stop_Torch_Crackling", barrierFire);

            barrierFire.SetActive(false);

            //Wwise
            puzzleThreeAudioBool = true;
        }
    }
}