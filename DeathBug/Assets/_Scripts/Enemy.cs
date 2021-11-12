using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    public void MoveToGoal(Vector3 goalPosition)
    {
        transform.DOMove(goalPosition, 2f).SetEase(Ease.Linear);
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        // gameObject.SetActive(false);
        GameManager.instance.score++;
        GameManager.instance.gameUI.UpdateScore(GameManager.instance.score);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Goal")
        {
            Debug.Log("Goal");
            GameManager.instance.GameOver();
        }
    }

}
