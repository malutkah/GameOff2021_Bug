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
    public static GameManager instance;
    public GameObject target;
    public GameState gameState = GameState.Start;
    [HideInInspector] public UI gameUI;
    public GameObject spawnManager;
    public int score = 0;
    public float timeToReachGoal = 2f;

    private GameObject enemyBeetle;
    private Enemy enemy;
    private TextMeshProUGUI scoreText;
    private SpawnManager enemySpawner;
    private float timer = .95f;
    private AudioSource source;
    private Sounds sounds;

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

    #region Sound

        IEnumerator PlayBgSounds()
    {
        FindObjectOfType<AudioManager>().PlaySound("Test");

        yield return new WaitForSeconds(source.clip.length);

        StartCoroutine(PlayBgSounds());
    }

    void PlayNextSong()
    {
        StartCoroutine(PlayBgSounds());
    }

    #endregion

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

        enemySpawner = spawnManager.GetComponent<SpawnManager>();
        
        source = GetComponent<AudioSource>();
        source = GameObject.Find("AudioManager").GetComponent<AudioSource>();

        StartCoroutine(PlayBgSounds());
    }

    void Start()
    {
        gameUI = gameObject.GetComponent<UI>();

        gameUI.UpdateScore(score);

        gameState = GameState.Playing;
    }

    private void Update()
    {
        
    }

    #endregion

}
