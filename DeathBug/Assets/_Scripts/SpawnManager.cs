using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [HideInInspector] public EnemyData enemyData;
    private GameObject newEnemyGO;
    private GameObject beetle1, beetle2, beetle3, beetle4, beetle5;
    private GameObject target;
    private bool spawnBeetle1 = false, spawnBeetle2 = false, spawnBeetle3 = false, spawnBeetle4 = false, spawnBeetle5 = false;

    private void Awake()
    {
        Time.timeScale = 1f;
        target = GameObject.FindGameObjectWithTag("Goal");
    }

    void Start()
    {
        Time.timeScale = 1f;

        string pathPrefix = "_ScriptableObjects/";
        beetle1 = LoadBeetle(pathPrefix + "Beetle 1");
        beetle2 = LoadBeetle(pathPrefix + "Beetle 2");
        beetle3 = LoadBeetle(pathPrefix + "Beetle 3");
        beetle4 = LoadBeetle(pathPrefix + "Beetle 4");
        beetle5 = LoadBeetle(pathPrefix + "Beetle 5");
    }

    private void Update()
    {
        if (GameManager.instance.score == beetle1.GetComponent<Enemy>().firstAppearanceAtScore && !spawnBeetle1)
        {
            spawnBeetle1 = true;
            StartCoroutine(SpawnBeetle(beetle1));
        }

        if (GameManager.instance.score == beetle2.GetComponent<Enemy>().firstAppearanceAtScore && !spawnBeetle2)
        {
            spawnBeetle2 = true;
            StartCoroutine(SpawnBeetle(beetle2));
        }

        if (GameManager.instance.score >= beetle3.GetComponent<Enemy>().firstAppearanceAtScore && !spawnBeetle3)
        {
            spawnBeetle3 = true;
            StartCoroutine(SpawnBeetle(beetle3));
        }

        if (GameManager.instance.score >= beetle4.GetComponent<Enemy>().firstAppearanceAtScore && !spawnBeetle4)
        {
            spawnBeetle4 = true;
            StartCoroutine(SpawnBeetle(beetle4));
        }

        if (GameManager.instance.score >= beetle5.GetComponent<Enemy>().firstAppearanceAtScore && !spawnBeetle5)
        {
            spawnBeetle5 = true;
            StartCoroutine(SpawnBeetle(beetle5));
        }
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

    #endregion

    private GameObject LoadBeetle(string pathToScript)
    {
        var _enemyData = Resources.Load<EnemyData>(pathToScript);
        GameObject beetle = _enemyData.enemyPrefab;
        beetle.GetComponent<Enemy>().scoreValue = _enemyData.scoreValue;
        beetle.GetComponent<Enemy>().hitPoints = _enemyData.hitPoints;
        beetle.GetComponent<Enemy>().timeToReachGoal = _enemyData.timeToReachGoal;
        beetle.GetComponent<Enemy>().goalPosition = getTargetPositionAsVector2();
        beetle.GetComponent<Enemy>().firstAppearanceAtScore = _enemyData.firstAppearanceAtScore;
        beetle.GetComponent<Enemy>().spawnRate = _enemyData.spawnRate;

        return beetle;
    }

    private IEnumerator SpawnBeetle(GameObject enemy){
        yield return new WaitForSeconds(enemy.GetComponent<Enemy>().spawnRate);
        InstantiateEnemyAtRandomPosition(enemy);
        StartCoroutine(SpawnBeetle(enemy));
    }
}
