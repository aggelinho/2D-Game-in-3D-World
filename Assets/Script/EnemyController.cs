using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator enemyAnimation;
    private bool isDead = false;

    void Start()
    {
        enemyAnimation = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isDead) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            isDead = true;

            if (enemyAnimation != null)
            {
                enemyAnimation.SetBool("Death_b", true);
                enemyAnimation.SetInteger("DeathType_int",1);
            }

            MoveLeft move = GetComponent<MoveLeft>();
            if (move != null)
            {
                move.enabled = false;
            }

            Destroy(gameObject, 1.5f);
        }
    }
}
