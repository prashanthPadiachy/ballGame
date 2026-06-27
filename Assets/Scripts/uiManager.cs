using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class uiManager : MonoBehaviour
{
    [Header("Input")]
    public InputActionReference pauseAction;

    [Header("Panels")]
    public GameObject pausePanel;
    public GameObject levelCompletePanel;

    [Header("Text")]
    public TMP_Text scoreFormulaText;
    public TMP_Text finalScoreText;

    [Header("Score")]
    public int score = 0;

    [Header("Score Calculation")]
    public countdownTimer timer;
    public collectibleManager collectibles;

    public int finalScore;

    private bool isPaused = false;
    private bool levelComplete = false;

    private void OnEnable()
    {
        pauseAction.action.performed += OnPausePressed;
        pauseAction.action.Enable();
    }

    private void OnDisable()
    {
        pauseAction.action.performed -= OnPausePressed;
        pauseAction.action.Disable();
    }

    private void Start()
    {
        pausePanel.SetActive(false);
        levelCompletePanel.SetActive(false);
        Time.timeScale = 1f;
        timer = GameObject.Find("Timer").GetComponent<countdownTimer>();
        collectibles = GameObject.Find("CollectibleManager").GetComponent<collectibleManager>();
    }

    private int CalculateFinalScore()
    {
        float time = timer.timeLeft;
        int collectibleCount = collectibles.count;

        float score = time * (1f + 0.1f * collectibleCount);

        return Mathf.RoundToInt(score);
    }

    private void OnPausePressed(InputAction.CallbackContext context)
    {
        if (levelComplete) return;

        if (isPaused)
            Resume();
        else
            Pause();
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void LevelComplete()
    {
        levelComplete = true;
        isPaused = false;

        pausePanel.SetActive(false);
        levelCompletePanel.SetActive(true);

        timer.StopTimer();

        float time = timer.timeLeft;
        int collectibleCount = collectibles.count;

        float multiplier = 1f + 0.1f * collectibleCount;
        finalScore = Mathf.RoundToInt(time * multiplier);

        scoreFormulaText.text =
            "Score = " + Mathf.CeilToInt(time) + " X " + multiplier.ToString("0.0");

        finalScoreText.text =
            "Final Score: " + finalScore;

        Time.timeScale = 0f;
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        MusicManager.StopMusic();
        SceneManager.LoadScene(0); 
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;

        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
    }
}
