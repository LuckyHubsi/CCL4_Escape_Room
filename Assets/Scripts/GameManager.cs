using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private float gameTime = 300f; // Game duration in seconds

    [SerializeField]
    private float smokeTime = 60f; // Smoke duration in seconds

    [SerializeField]
    private RawImage smokeOverlay; // UI Image for smoke effect

    [SerializeField]
    private ParticleSystem smokeParticles;

    private float initialSmokeTime; // Store the initial smoke time

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
        initialSmokeTime = smokeTime;
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

        if (!puzzleOneSolved)
        {
            if (smokeTime > 0)
            {
                smokeTime -= Time.deltaTime;
                UpdateSmokeOverlay();

                if (smokeTime <= 0)
                {
                    LoadLoseScene();
                }
            }
        }
        else
        {
            smokeTime = initialSmokeTime;
            UpdateSmokeOverlay();
            smokeParticles.Stop();
        }

        PuzzleCompletionStatus();
    }

    private void LoadLoseScene()
    {
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.Lose);
    }

    public float GetRemainingGameTime()
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

    private void UpdateSmokeOverlay()
    {
        float alpha = Mathf.Clamp01(1 - (smokeTime / initialSmokeTime));
        Color color = smokeOverlay.color;
        color.a = alpha;
        smokeOverlay.color = color;
    }
}
