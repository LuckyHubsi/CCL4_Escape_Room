using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionManager : MonoBehaviour
{
    public static ProgressionManager instance;

    [SerializeField]
    private GameObject barrierOne;
    [SerializeField]
    private GameObject barrierTwo;
    [SerializeField]
    private GameObject barrierFire;
    [SerializeField]
    private GameObject barrierMirror;

    public bool puzzleOneSolved = false;
    public bool puzzleTwoSolved = false;
    public bool puzzleThreeSolved = false;

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
            barrierFire.SetActive(false);
        }
    }
}