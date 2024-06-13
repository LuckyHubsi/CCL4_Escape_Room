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

    [SerializeField]
    private GameObject[] torches; // Array of torch game objects

    [SerializeField]
    private GameObject smokeRef; // Reference to smoke gameobject for sound

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

        // Initialization that should only happen once
        initialSmokeTime = smokeTime;
    }

    private void Start()
    {
        DisableAllOutlines();

        // Load torch data
        TorchData_Loader.LoadTorchData(torches);
    }

    private void Update()
    {
        UpdateGameTime();
        UpdateSmokeTime();
    }

    private void UpdateGameTime()
    {
        if (gameTime > 0)
        {
            gameTime -= Time.deltaTime;
            if (gameTime <= 0)
            {
                LoadLoseScene();
            }
        }
    }

    private void UpdateSmokeTime()
    {
        if (!ProgressionManager.instance.puzzleOneSolved)
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
            if (smokeParticles.isPlaying)
            {
                smokeParticles.Stop();
                AkSoundEngine.PostEvent("Stop_Smoke", smokeRef);
            }
        }
    }

    private void LoadLoseScene()
    {
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.Lose);
    }

    public float GetRemainingGameTime()
    {
        return Mathf.Max(gameTime, 0);
    }

    public float GetRemainingSmokeTimer()
    {
        return Mathf.Max(smokeTime, 0);
    }

    private void DisableAllOutlines()
    {
        Outline[] outlines = FindObjectsOfType<Outline>();
        foreach (Outline outline in outlines)
        {
            outline.enabled = false;
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
