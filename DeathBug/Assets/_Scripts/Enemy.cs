using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
      public void MoveToGoal(Vector3 goalPosition)
    {
        transform.DOMove(goalPosition, 1.8f);
    }

    private void OnMouseDown() {
        // Destroy(gameObject);
        gameObject.SetActive(false);
        GameManager.instance.score++;
        GameManager.instance.gameUI.UpdateScore(GameManager.instance.score);
    }

}
