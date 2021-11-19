using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    public int damage;

    public void MoveToGoal(Vector3 goalPosition, float timeToReachGoal)
    {
        transform.DOMove(goalPosition, timeToReachGoal).SetEase(Ease.Linear);
    }

    private void OnMouseDown()
    {
        if (GameManager.instance.gameState == GameState.Playing)
        {
            Destroy(gameObject);
            
            GameManager.instance.score++;
            GameManager.instance.gameUI.UpdateScore(GameManager.instance.score);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Goal")
        {
            Debug.Log("Goal");
            Target.instance.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
