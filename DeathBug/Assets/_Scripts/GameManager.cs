using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public enum GameState
{
    Start,
    Playing,
    GameOver
}

public class GameManager : MonoBehaviour
{
    public GameObject enemyBeetlePrefab;
    public GameObject goal;
    public static GameManager instance;
    public int score = 0;
    public UI gameUI;
    public GameState gameState = GameState.Start;

    private GameObject enemyBeetle;
    private Enemy enemy;
    private float timer = .95f;
    private TextMeshProUGUI scoreText;

    public void SpawnEnemy()
    {
        enemyBeetle = Instantiate(
            enemyBeetlePrefab,
            new Vector2(10, Random.Range(0, 4)),
            Quaternion.identity
            );

        enemy = enemyBeetle.GetComponent<Enemy>();
    }

    public void GameOver()
    {
        gameState = GameState.GameOver;
        gameUI.GameOver();
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        SpawnEnemy();

        enemy.MoveToGoal(goal.transform.position);
        gameUI = gameObject.GetComponent<UI>();

        gameUI.UpdateScore(score);

        gameState = GameState.Playing;
    }

    private void Update()
    {
        if (gameState == GameState.Playing)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                SpawnEnemy();
                enemy.MoveToGoal(goal.transform.position);
                timer = .95f;
            }
        }
    }
}
