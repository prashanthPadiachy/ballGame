using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class countdownTimer : MonoBehaviour
{
    public TMP_Text timerText;
    public float timeLeft = 60f;

    public bool timerRunning = true;

    private void Awake()
    {
        timerText = GameObject.Find("timerText").GetComponent<TMP_Text>();
    }

    private void Update()
    {
        if (!timerRunning) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0)
        {
            timeLeft = 0;
            timerRunning = false;
            Debug.Log("Timer finished!");
        }

        UpdateTimerText();
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timeLeft / 60);
        int seconds = Mathf.FloorToInt(timeLeft % 60);

        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}

