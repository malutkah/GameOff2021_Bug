using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        scoreText.text = "Game Over";
        
        Time.timeScale = 0f; // freeze game
    }
}
