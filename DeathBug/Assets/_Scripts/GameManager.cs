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
    public GameObject target;
    
    public static GameManager instance;
    public int score = 0;
    public UI gameUI;
    public GameState gameState = GameState.Start;
    public float timeToReachGoal = 2f;

    private GameObject enemyBeetle;
    private Enemy enemy;
    private float timer = .95f;
    private TextMeshProUGUI scoreText;

    public void GameOver()
    {
        gameState = GameState.GameOver;
        gameUI.GameOver();
    }

    // create a function that rotates the enemy towards the target
    public void FaceToGameObject(GameObject lookingTarget, GameObject targetToLookAt)
    {
        // get the direction from the enemy to the target
        Vector3 direction = targetToLookAt.transform.position - lookingTarget.transform.position;

        // get the angle between the direction and the x-axis
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // rotate the enemy to the angle
        lookingTarget.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
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
        gameUI = gameObject.GetComponent<UI>();

        gameUI.UpdateScore(score);

        gameState = GameState.Playing;
    }

    #endregion

}
