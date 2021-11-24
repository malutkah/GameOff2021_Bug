using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [HideInInspector] public EnemyData enemyData;
    private GameObject enemyGO, newEnemyGO;
    private GameObject beetle0, beetle10, beetle25, beetle50, beetle100;
    private GameObject target;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Goal");
    }

    void Start()
    {
        StartCoroutine(LoadScriptableObjectEnemy());
    }

    private Vector2 getTargetPositionAsVector2()
    {
        return new Vector2(target.transform.position.x, target.transform.position.y);
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

    private IEnumerator LoadScriptableObjectEnemy()
    {
        if (GameManager.instance.score >= 0)
        {
            // spawn enemey 0
            enemyData = Resources.Load<EnemyData>("_ScriptableObjects/Beetle");
            beetle0 = enemyData.enemyPrefab;
            beetle0.GetComponent<Enemy>().scoreValue = enemyData.scoreValue;
            beetle0.GetComponent<Enemy>().hitPoints = enemyData.hitPoints;
            beetle0.GetComponent<Enemy>().timeToReachGoal = enemyData.timeToReachGoal;
            beetle0.GetComponent<Enemy>().goalPosition = getTargetPositionAsVector2();
            InstantiateEnemyAtRandomPosition(beetle0);
            yield return new WaitForSeconds(enemyData.spawnRate);
        }
        if (GameManager.instance.score >= 10)
        {
            // spawn enemey 10
            enemyData = Resources.Load<EnemyData>("_ScriptableObjects/Beetle 2");
            beetle10 = enemyData.enemyPrefab;
            beetle10.GetComponent<Enemy>().scoreValue = enemyData.scoreValue;
            beetle10.GetComponent<Enemy>().hitPoints = enemyData.hitPoints;
            beetle10.GetComponent<Enemy>().timeToReachGoal = enemyData.timeToReachGoal;
            beetle10.GetComponent<Enemy>().goalPosition = getTargetPositionAsVector2();
            InstantiateEnemyAtRandomPosition(beetle10);
            yield return new WaitForSeconds(enemyData.spawnRate);
        }
        if (GameManager.instance.score >= 25)
        {
            // spawn enemy 25
            enemyData = Resources.Load<EnemyData>("_ScriptableObjects/Beelte 3");
            beetle25 = enemyData.enemyPrefab;
            beetle25.GetComponent<Enemy>().scoreValue = enemyData.scoreValue;
            beetle25.GetComponent<Enemy>().hitPoints = enemyData.hitPoints;
            beetle25.GetComponent<Enemy>().timeToReachGoal = enemyData.timeToReachGoal;
            beetle25.GetComponent<Enemy>().goalPosition = getTargetPositionAsVector2();
            InstantiateEnemyAtRandomPosition(beetle25);
            yield return new WaitForSeconds(enemyData.spawnRate);
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
        
        StartCoroutine(LoadScriptableObjectEnemy());
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

    private IEnumerator SpawnEnemyOverTime(float spawnRate)
    {
        LoadScriptableObjectEnemy();
        yield return new WaitForSeconds(spawnRate);
        StartCoroutine(LoadScriptableObjectEnemy());
    }
    #endregion
}
