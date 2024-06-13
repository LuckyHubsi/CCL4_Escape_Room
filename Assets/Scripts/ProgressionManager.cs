using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProgressionManager : MonoBehaviour
{
    public static ProgressionManager instance;

    public UnityEvent onPuzzleOneSolved;
    public UnityEvent onPuzzleTwoSolved;
    public UnityEvent onPuzzleThreeSolved;

    [SerializeField]
    private GameObject barrierOne;
    [SerializeField]
    private GameObject barrierTwo;
    [SerializeField]
    private GameObject barrierThree;
    [SerializeField]
    private GameObject barrierMirror;

    public bool puzzleOneSolved = false;
    public bool puzzleTwoSolved = false;
    public bool puzzleThreeSolved = false;

    private void Awake()
    {
        // Ensure singleton pattern
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
        onPuzzleOneSolved?.Invoke();
        UpdateBarriers();
    }

    public void SolvePuzzleTwo()
    {
        puzzleTwoSolved = true;
        onPuzzleTwoSolved?.Invoke();
        UpdateBarriers();
    }

    public void SolvePuzzleThree()
    {
        puzzleThreeSolved = true;
        onPuzzleThreeSolved?.Invoke();
        UpdateBarriers();
    }

    private void UpdateBarriers()
    {
        if (puzzleOneSolved)
        {
            barrierOne.SetActive(false);
            barrierMirror.SetActive(false);
        }
        if (puzzleTwoSolved)
        {
            barrierTwo.SetActive(false);
        }
        if (puzzleThreeSolved)
        {
            barrierThree.SetActive(false);
        }
    }
}
