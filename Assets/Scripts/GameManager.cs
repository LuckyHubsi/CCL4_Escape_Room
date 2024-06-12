using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private float gameTime = 300f; // Game duration in seconds

    #region PuzzleStates

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

    #endregion

    void Start()
    {
        if (instance != null)
        {
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);

        DisableAllOutlines();
    }

    void Update()
    {
        if (gameTime > 0)
        {
            gameTime -= Time.deltaTime;
            if (gameTime <= 0)
            {
                LoadLoseScene();
            }
        }

        PuzzleCompletionStatus();
    }

    private void LoadLoseScene()
    {
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.Lose);
    }

    public float GetRemainingTime()
    {
        return Mathf.Max(gameTime, 0);
    }

    private void DisableAllOutlines()
    {
        Outline[] outlines = FindObjectsOfType<Outline>();
        foreach (Outline outline in outlines)
        {
            outline.enabled = false;
        }
    }

    private void PuzzleCompletionStatus()
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
