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
    public float timeToReachGoal = 2f;

    private GameObject enemyBeetle;
    private Enemy enemy;
    private float timer = .95f;
    private TextMeshProUGUI scoreText;

    #region Enemy Spawning
    public void InstantiateEnemyAtRandomPosition()
    {
        int random = Random.Range(0, 3);

        switch (random)
        {
            case 0:
                CreateEnemyRight();
                break;
            case 1:
                CreateEnemyLeft();
                break;
            case 2:
                CreateEnemyTop();
                break;
            case 3:
                CreateEnemyBottom();
                break;
        }

        enemy = enemyBeetle.GetComponent<Enemy>();
    }

    private void CreateEnemyRight()
    {
        enemyBeetle = Instantiate(
                    enemyBeetlePrefab,
                    new Vector2(10, Random.Range(-4, 4)),
                    Quaternion.identity
                    );
    }

    private void CreateEnemyLeft()
    {
        enemyBeetle = Instantiate(
                    enemyBeetlePrefab,
                    new Vector2(-10, Random.Range(-4, 4)),
                    Quaternion.identity
                    );
    }

    private void CreateEnemyTop()
    {
        enemyBeetle = Instantiate(
                    enemyBeetlePrefab,
                    new Vector2(Random.Range(-7, 7), 6),
                    Quaternion.identity
                    );
    }

    private void CreateEnemyBottom()
    {
        enemyBeetle = Instantiate(
                    enemyBeetlePrefab,
                    new Vector2(Random.Range(-7, 7), -6),
                    Quaternion.identity
                    );
    }
    #endregion

    public void GameOver()
    {
        gameState = GameState.GameOver;
        gameUI.GameOver();
    }

    #region Unity Functions
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
        InstantiateEnemyAtRandomPosition();

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
                InstantiateEnemyAtRandomPosition();
                enemy.MoveToGoal(goal.transform.position);
                timer = .95f;
            }
        }
    }
    #endregion

}
