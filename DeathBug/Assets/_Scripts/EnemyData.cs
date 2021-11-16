using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "EnemyData")]
public class EnemyData : ScriptableObject
{
    public int hitPoints;
    public int scoreValue;
    public float timeToReachGoal; // in seconds
    public float spawnRate; // in seconds
    public int firstAppearanceAtScore;
    public GameObject enemyPrefab;
}
