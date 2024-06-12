using UnityEngine;
using UnityEngine.UI;

public class UITimer : MonoBehaviour
{
    [SerializeField]
    private Text timerText;

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