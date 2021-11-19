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
        // Debug.Log("SpawnManager Start");
        StartCoroutine(SpawnEnemyOverTime());
        // LoadEnemyData();
        // SpawnEnemy();
    }

    #region Enemy Spawning
    public void InstantiateEnemyAtRandomPosition()
    {
        int random = Random.Range(0, 3);

        switch (GameManager.instance.score)
        {
            case 0:
                // load scriptableobject from resources
                enemyData = Resources.Load<EnemyData>("_ScriptableObjects/Beetle");
                enemyGO = enemyData.enemyPrefab;
                break;

            case 10:
                enemyData = Resources.Load<EnemyData>("_ScriptableObjects/Beetle 2");
                enemyGO = enemyData.enemyPrefab;
                break;

            case 25:
                Debug.Log("Spawn level 25 bug");
                break;

            case 50:
                Debug.Log("Spawn level 50 bug");
                break;

            case 100:
                Debug.Log("Spawn level 100 bug");
                break;
        }



        if (enemyGO != null)
        {
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

            // enemyGO.transform.SetParent(transform);
            enemy = enemyGO.GetComponent<Enemy>();
            enemy.damage = enemyData.hitPoints;
        }
    }

    private void CreateEnemyRight()
    {
        var pos = new Vector2(10, Random.Range(-4, 4));
        Instantiate(enemyGO, pos, Quaternion.identity);
    }

    private void CreateEnemyLeft()
    {
        var pos = new Vector2(-10, Random.Range(-4, 4));
        Instantiate(enemyGO, pos, Quaternion.identity);
    }

    private void CreateEnemyTop()
    {
        var pos = new Vector2(Random.Range(-7, 7), 6);
        Instantiate(enemyGO, pos, Quaternion.identity);
    }

    private void CreateEnemyBottom()
    {
        var pos = new Vector2(Random.Range(-7, 7), -6);
        Instantiate(enemyGO, pos, Quaternion.identity);
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
        InstantiateEnemyAtRandomPosition();
        enemy.MoveToGoal(target.transform.position, enemyData.timeToReachGoal);
        GameManager.instance.FaceToGameObject(enemyGO, target);
    }
    #endregion
}
