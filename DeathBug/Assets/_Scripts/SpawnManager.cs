using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public EnemyData enemyData;
    private float timer;
    private GameObject enemyGO;
    private GameObject target;
    private Enemy enemy;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Goal");
    }

    void Start()
    {
        timer = enemyData.spawnRate;
        // Debug.Log("SpawnManager Start");
        StartCoroutine(SpawnEnemyOverTime());
        // LoadEnemyData();
        // SpawnEnemy();
    }

    #region Loading ScriptableObjects

    private void LoadEnemyData()
    {
        if (GameManager.instance.score == enemyData.firstAppearanceAtScore)
        {
            // Load the EnemyData scriptable object
            InstantiateEnemyAtRandomPosition();
        }
    }

    #endregion

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

        if (enemyGO != null)
        {
            enemyGO.transform.SetParent(transform);
            enemy = enemyGO.GetComponent<Enemy>();
            enemy.damage = enemyData.hitPoints;
        }
    }

    private void CreateEnemyRight()
    {
        var pos = new Vector2(10, Random.Range(-4, 4));
        enemyGO = Instantiate(enemyData.enemyPrefab, pos, Quaternion.identity);
    }

    private void CreateEnemyLeft()
    {
        var pos = new Vector2(-10, Random.Range(-4, 4));
        enemyGO = Instantiate(enemyData.enemyPrefab, pos, Quaternion.identity);
    }

    private void CreateEnemyTop()
    {
        var pos = new Vector2(Random.Range(-7, 7), 6);
        enemyGO = Instantiate(enemyData.enemyPrefab, pos, Quaternion.identity);
    }

    private void CreateEnemyBottom()
    {
        var pos = new Vector2(Random.Range(-7, 7), -6);
        enemyGO = Instantiate(enemyData.enemyPrefab, pos, Quaternion.identity);
    }

    private IEnumerator SpawnEnemyOverTime()
    {
        SpawnEnemy();
        // Debug.Log("Spawning enemy");
        yield return new WaitForSeconds(enemyData.spawnRate);
        StartCoroutine(SpawnEnemyOverTime());
    }

    private void SpawnEnemy()
    {
        LoadEnemyData();
        enemy.MoveToGoal(target.transform.position, enemyData.timeToReachGoal);
        GameManager.instance.FaceToGameObject(enemyGO, target);
    }
    #endregion
}
