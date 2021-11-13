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
        var pos = new Vector2(10, Random.Range(-4, 4));
        enemyBeetle = Instantiate(enemyBeetlePrefab, pos, Quaternion.identity);
    }

    private void CreateEnemyLeft()
    {
        var pos = new Vector2(-10, Random.Range(-4, 4));
        enemyBeetle = Instantiate(enemyBeetlePrefab, pos, Quaternion.identity);
    }

    private void CreateEnemyTop()
    {
        var pos = new Vector2(Random.Range(-7, 7), 6);
        enemyBeetle = Instantiate(enemyBeetlePrefab, pos, Quaternion.identity);
    }

    private void CreateEnemyBottom()
    {
        var pos = new Vector2(Random.Range(-7, 7), -6);
        enemyBeetle = Instantiate(enemyBeetlePrefab, pos, Quaternion.identity);
    }

    private void SpawnEnemyOverTime()
    {
        if (gameState == GameState.Playing)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                InstantiateEnemyAtRandomPosition();
                enemy.MoveToGoal(goal.transform.position);
                FaceToGameObject(enemyBeetle, goal);
                timer = .95f;
            }
        }
    }
    #endregion

    public void GameOver()
    {
        gameState = GameState.GameOver;
        gameUI.GameOver();
    }

    // create a function that rotates the enemy towards the goal
    public void FaceToGameObject(GameObject obj, GameObject goal)
    {
        // get the direction from the enemy to the goal
        Vector3 direction = goal.transform.position - obj.transform.position;
        // get the angle between the direction and the x-axis
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // rotate the enemy to the angle
        obj.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
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
        SpawnEnemyOverTime();
    }

    #endregion

}
