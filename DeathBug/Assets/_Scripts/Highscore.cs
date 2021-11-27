using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Highscore : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Highscore"))
        {
            highScoreText.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
        }
    }
}