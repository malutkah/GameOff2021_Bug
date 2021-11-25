using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UI : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public TextMeshProUGUI scoreText, highScoreText, text;
    public TextMeshProUGUI cooldownText;
    public GameObject pauseMenuUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // normal game

        GameIsPaused = false;
    }
   
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // freeze game

        GameIsPaused = true;
    }

    public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void UpdateCooldwon(float timeLeft)
    {
        cooldownText.text = Mathf.Round(timeLeft).ToString();
    }

    public void GameOver()
    {
        scoreText.text = "Game Over";
        highScoreText.text = GameManager.instance.score.ToString();
        highScoreText.gameObject.SetActive(true);
        text.gameObject.SetActive(true);
        pauseMenuUI.SetActive(true);

        Time.timeScale = 0f; // freeze game

        // destroy all game objects with the tag "Enemy"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        pauseMenuUI.SetActive(false);
    }
}
