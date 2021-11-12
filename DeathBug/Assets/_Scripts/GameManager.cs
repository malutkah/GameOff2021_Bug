using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject enemyBeetlePrefab;
    public GameObject goal;
    public static GameManager instance;
    public int score;
    public UI gameUI;

    private GameObject enemyBeetle;
    private Enemy enemy;
    private float timer = .95f;
    private TextMeshProUGUI scoreText;

    public void SpawnEnemy()
    {
        enemyBeetle = Instantiate(enemyBeetlePrefab, new Vector2(10, Random.Range(0, 4)), Quaternion.identity);
        enemy = enemyBeetle.GetComponent<Enemy>();
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
    }

    private void Update()
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
