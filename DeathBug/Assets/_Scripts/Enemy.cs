using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    public int hitPoints;
    public int scoreValue;
    public float timeToReachGoal;
    public Vector2 goalPosition;
    private void Awake()
    {
        MoveToGoal();
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
        if (GameManager.instance.gameState == GameState.Playing)
        {
            Destroy(gameObject);

            GameManager.instance.score += scoreValue;
            GameManager.instance.gameUI.UpdateScore(GameManager.instance.score);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Goal")
        {
            Debug.Log("Goal");
            Target.instance.TakeDamage(hitPoints);
            Destroy(gameObject);
        }
    }
}
