using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public float startTime = 60f; // seconds

    public TMP_Text timerText;

    public UnityEvent onTimerEnd;

    private float currentTime;
    private bool isRunning = false;

    void Start()
    {
        currentTime = startTime;
        UpdateUI();
        StartTimer();
    }

    void Update()
    {
        if (!isRunning) return;

        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateUI();
        }
        else
        {
            currentTime = 0;
            isRunning = false;
            UpdateUI();
            onTimerEnd?.Invoke();
        }
    }

    public void StartTimer()
    {
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void ResetTimer()
    {
        currentTime = startTime;
        UpdateUI();
    }

    void UpdateUI()
    {

        if (!timerText) return;

        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        timerText.text = $"{minutes:00}:{seconds:00}";

        if (currentTime <= 10f)
            timerText.color = Color.red;
        else
            timerText.color = Color.white;

    }
}
