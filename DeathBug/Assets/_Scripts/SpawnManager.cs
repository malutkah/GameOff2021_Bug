using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpawnManager : MonoBehaviour
{
    [HideInInspector] public EnemyData enemyData;
    private float timer;
    private GameObject enemyGO, newEnemyGO;
    private GameObject beetle0, beetle10, beetle25, beetle50, beetle100;
    private GameObject target;
    private Enemy enemy;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Goal");
    }

    void Start()
    {
        // Debug.Log("SpawnManager Start");
        StartCoroutine(SpawnEnemyOverTime());
        // LoadEnemyData();
        // SpawnEnemy();
    }

    #region Enemy Spawning
    public void InstantiateEnemyAtRandomPosition(GameObject enemyToSpawn)
    {
        int random = Random.Range(0, 3);

            switch (random)
            {
                case 0:
                    CreateEnemyRight(enemyToSpawn);
                    break;
                case 1:
                    CreateEnemyLeft(enemyToSpawn);
                    break;
                case 2:
                    CreateEnemyTop(enemyToSpawn);
                    break;
                case 3:
                    CreateEnemyBottom(enemyToSpawn);
                    break;
            }
    }

    private void LoadScriptableObjectEnemy()
    {
        if (GameManager.instance.score >= 0)
        {
            // spawn enemey 0
            enemyData = Resources.Load<EnemyData>("_ScriptableObjects/Beetle");
            beetle0 = enemyData.enemyPrefab;
            beetle0.GetComponent<Enemy>().scoreValue = enemyData.scoreValue;
            beetle0.GetComponent<Enemy>().hitPoints = enemyData.hitPoints;
            InstantiateEnemyAtRandomPosition(beetle0);
        }
        if (GameManager.instance.score >= 10)
        {
            // spawn enemey 1
            enemyData = Resources.Load<EnemyData>("_ScriptableObjects/Beetle 2");
            beetle10 = enemyData.enemyPrefab;
            beetle10.GetComponent<Enemy>().scoreValue = enemyData.scoreValue;
            beetle10.GetComponent<Enemy>().hitPoints = enemyData.hitPoints;
            InstantiateEnemyAtRandomPosition(beetle10);
        }
        if (GameManager.instance.score >= 25)
        {
            // spawn enemy 25
            Debug.Log("Spawn level 25 bug");
        }
        if (GameManager.instance.score >= 50)
        {
            // spawn eenemy 50
            Debug.Log("Spawn level 50 bug");
        }
        if (GameManager.instance.score >= 100)
        {
            // spawn enemy 100
            Debug.Log("Spawn level 100 bug");
        }

        enemy = newEnemyGO.GetComponent<Enemy>();
    }

    private void CreateEnemyRight(GameObject enemyToSpawn)
    {
        var pos = new Vector2(10, Random.Range(-4, 4));
        newEnemyGO = Instantiate(enemyToSpawn, pos, Quaternion.identity);
    }

    private void CreateEnemyLeft(GameObject enemyToSpawn)
    {
        var pos = new Vector2(-10, Random.Range(-4, 4));
        newEnemyGO = Instantiate(enemyToSpawn, pos, Quaternion.identity);
    }

    private void CreateEnemyTop(GameObject enemyToSpawn)
    {
        var pos = new Vector2(Random.Range(-7, 7), 6);
        newEnemyGO = Instantiate(enemyToSpawn, pos, Quaternion.identity);
    }

    private void CreateEnemyBottom(GameObject enemyToSpawn)
    {
        var pos = new Vector2(Random.Range(-7, 7), -6);
        newEnemyGO = Instantiate(enemyToSpawn, pos, Quaternion.identity);
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
        LoadScriptableObjectEnemy();
        enemy.MoveToGoal(new Vector2(target.transform.position.x, target.transform.position.y), enemyData.timeToReachGoal);
        GameManager.instance.FaceToGameObject(newEnemyGO, target);
    }
    #endregion
}
