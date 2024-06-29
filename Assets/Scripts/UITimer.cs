using UnityEngine;
using UnityEngine.UI;

// Script for the timer at the top of the screen
public class UITimer : MonoBehaviour
{
    public static UITimer instance;

    [SerializeField]
    private Text timerText;

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

    private void Update()
    {
        if (GameManager.instance != null && timerText != null)
        {
            float remainingTime = GameManager.instance.GetRemainingGameTime();
            timerText.text = FormatTime(remainingTime);
        }
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}