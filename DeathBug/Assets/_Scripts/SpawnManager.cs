using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [HideInInspector] public EnemyData enemyData;
    private GameObject enemyGO, newEnemyGO;
    private GameObject beetle0, beetle10, beetle25, beetle50, beetle100;
    private GameObject target;
    private bool hit10once = false, hit25once = false, hit50once = false, hit100once = false;

    private void Awake()
    {
        Time.timeScale = 1f;
        target = GameObject.FindGameObjectWithTag("Goal");
    }

    void Start()
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadBeetle0());
    }

    private void Update()
    {
        if (GameManager.instance.score == 10 && !hit10once)
        {
            hit10once = true;
            StartCoroutine(LoadBeetle10());
        }
        else if (GameManager.instance.score >= 25 && !hit25once)
        {
            hit25once = true;
            StartCoroutine(LoadBeetle25());
        }
        else if (GameManager.instance.score >= 50 && !hit50once)
        {
            hit50once = true;
            StartCoroutine(LoadBeetle50());
        }
        else if (GameManager.instance.score >= 100 && !hit100once)
        {
            hit100once = true;
            StartCoroutine(LoadBeetle100());
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

    private IEnumerator LoadBeetle0()
    {
        var _enemyData = Resources.Load<EnemyData>("_ScriptableObjects/Beetle 1");
        beetle0 = _enemyData.enemyPrefab;
        beetle0.GetComponent<Enemy>().scoreValue = _enemyData.scoreValue;
        beetle0.GetComponent<Enemy>().hitPoints = _enemyData.hitPoints;
        beetle0.GetComponent<Enemy>().timeToReachGoal = _enemyData.timeToReachGoal;
        beetle0.GetComponent<Enemy>().goalPosition = getTargetPositionAsVector2();

        yield return new WaitForSeconds(_enemyData.spawnRate);
        InstantiateEnemyAtRandomPosition(beetle0);

        // LoadScriptableObjectEnemy?
        StartCoroutine(LoadBeetle0());
    }

    private IEnumerator LoadBeetle10()
    {
        var _enemyData = Resources.Load<EnemyData>("_ScriptableObjects/Beetle 2");
        beetle10 = _enemyData.enemyPrefab;
        beetle10.GetComponent<Enemy>().scoreValue = _enemyData.scoreValue;
        beetle10.GetComponent<Enemy>().hitPoints = _enemyData.hitPoints;
        beetle10.GetComponent<Enemy>().timeToReachGoal = _enemyData.timeToReachGoal;
        beetle10.GetComponent<Enemy>().goalPosition = getTargetPositionAsVector2();
        InstantiateEnemyAtRandomPosition(beetle10);

        yield return new WaitForSeconds(_enemyData.spawnRate);

        StartCoroutine(LoadBeetle10());
    }

    private IEnumerator LoadBeetle25()
    {
        var _enemyData = Resources.Load<EnemyData>("_ScriptableObjects/Beelte 3");
        beetle25 = _enemyData.enemyPrefab;
        beetle25.GetComponent<Enemy>().scoreValue = _enemyData.scoreValue;
        beetle25.GetComponent<Enemy>().hitPoints = _enemyData.hitPoints;
        beetle25.GetComponent<Enemy>().timeToReachGoal = _enemyData.timeToReachGoal;
        beetle25.GetComponent<Enemy>().goalPosition = getTargetPositionAsVector2();
        InstantiateEnemyAtRandomPosition(beetle25);

        yield return new WaitForSeconds(_enemyData.spawnRate);

        StartCoroutine(LoadBeetle25());
    }

    private IEnumerator LoadBeetle50()
    {
        var _enemyData = Resources.Load<EnemyData>("_ScriptableObjects/Beelte 4");
        beetle50 = _enemyData.enemyPrefab;
        beetle50.GetComponent<Enemy>().scoreValue = _enemyData.scoreValue;
        beetle50.GetComponent<Enemy>().hitPoints = _enemyData.hitPoints;
        beetle50.GetComponent<Enemy>().timeToReachGoal = _enemyData.timeToReachGoal;
        beetle50.GetComponent<Enemy>().goalPosition = getTargetPositionAsVector2();
        InstantiateEnemyAtRandomPosition(beetle50);

        yield return new WaitForSeconds(_enemyData.spawnRate);

        StartCoroutine(LoadBeetle50());
    }

    private IEnumerator LoadBeetle100()
    {
        var _enemyData = Resources.Load<EnemyData>("_ScriptableObjects/Beelte 5");
        beetle100 = _enemyData.enemyPrefab;
        beetle100.GetComponent<Enemy>().scoreValue = _enemyData.scoreValue;
        beetle100.GetComponent<Enemy>().hitPoints = _enemyData.hitPoints;
        beetle100.GetComponent<Enemy>().timeToReachGoal = _enemyData.timeToReachGoal;
        beetle100.GetComponent<Enemy>().goalPosition = getTargetPositionAsVector2();
        InstantiateEnemyAtRandomPosition(beetle100);

        yield return new WaitForSeconds(_enemyData.spawnRate);

        StartCoroutine(LoadBeetle100());
    }



    #region delete    
    #endregion
}
