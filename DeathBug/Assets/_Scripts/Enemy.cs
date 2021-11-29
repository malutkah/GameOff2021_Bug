using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    public int hitPoints;
    public int scoreValue;
    public int firstAppearanceAtScore;
    public float timeToReachGoal;
    public float spawnRate;
    public Vector2 goalPosition;
    private AudioSource source;
    private Sounds sounds;
    private Animator animator;

    private void Awake()
    {
        // somehow domove set timeScale = 0 when reloading scene
        Time.timeScale = 1f;

        MoveToGoal();

        source = GameObject.Find("AudioManager").GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    public void MoveToGoal()
    {
        transform.DOMove(goalPosition, timeToReachGoal).SetEase(Ease.Linear);
        GameManager.instance.FaceToGameObject(gameObject, GameManager.instance.target);
    }

    public void Print()
    {
        Debug.Log($"Enemy: {gameObject.name}");
    }

    private void OnMouseDown()
    {
        if (GameManager.instance.gameState == GameState.Playing && !GameManager.instance.gameUI.GameIsPaused)
        {
            int random = Random.Range(1, 4);

            switch (random)
            {
                case 1:
                    FindObjectOfType<AudioManager>().PlaySound("Kill 1");
                    break;
                case 2:
                    FindObjectOfType<AudioManager>().PlaySound("Kill 2");
                    break;
                case 3:
                    FindObjectOfType<AudioManager>().PlaySound("Kill 3");
                    break;
            }

            GameManager.instance.score += scoreValue;
            GameManager.instance.gameUI.UpdateScore(GameManager.instance.score);

            animator.SetTrigger("dead");
            WaitOneSecond();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Goal")
        {
            Target.instance.TakeDamage(hitPoints);
            Destroy(gameObject);
        }
    }

    private IEnumerator WaitOneSecond()
    {
        yield return new WaitForSeconds(1);
    }
}
