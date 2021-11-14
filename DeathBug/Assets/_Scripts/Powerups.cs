using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    private float cooldown = 10f;
    private bool activated = false;

    private void Update()
    {
        if (!gameObject.activeSelf)
        {
            cooldown -= Time.deltaTime;

            GameManager.instance.gameUI.UpdateCooldwon(cooldown);

            if (cooldown <= 0)
            {
                gameObject.SetActive(true);
                cooldown = 10f;
            }
        }
    }

    private void OnMouseDown()
    {
        gameObject.SetActive(false);

        if (gameObject.tag == "Item_Bomb")
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
                GameManager.instance.gameUI.UpdateScore(GameManager.instance.score++);
            }
        }
    }
}
