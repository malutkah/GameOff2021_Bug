using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Powerups : MonoBehaviour
{
    private float cooldown = 10f;
    private bool activated = false;
    private AudioSource source;
    private Sounds sounds;
    private Animator animator;

    private void Awake()
    {
        source = GameObject.Find("AudioManager").GetComponent<AudioSource>();
    }

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
            PlayKillSound();
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                animator = enemy.GetComponent<Animator>();
                animator.SetTrigger("dead");
                enemy.transform.DOMove(enemy.transform.position, 1).SetEase(Ease.Linear); // Stop Movement
                GameManager.instance.gameUI.UpdateScore(GameManager.instance.score++);
                enemy.GetComponent<Enemy>().setDead(true);
                StartCoroutine(KillEnemyAfterOneSecond(enemy));
            }
        }
    }

    private IEnumerator KillEnemyAfterOneSecond(GameObject gameObjectToBeKilled)
    {
        yield return new WaitForSeconds(0.75f);
        Destroy(gameObjectToBeKilled);
    }

    private void PlayKillSound()
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
        }
    }
}
