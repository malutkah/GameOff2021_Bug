using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    private int score = 0;

    private void Start() {
        GameManager.instance.gameUI.UpdateScore(score);
    }

      public void MoveToGoal(Vector3 goalPosition)
    {
        transform.DOMove(goalPosition, 1.8f);
    }

    private void OnMouseDown() {
        // Destroy(gameObject);
        gameObject.SetActive(false);
        score++;
        GameManager.instance.gameUI.UpdateScore(score);
    }

}
