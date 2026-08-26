using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    private bool finished = false;

    private void OnTriggerEnter(Collider other)
    {
        if (finished) return;

        if (other.CompareTag("Player"))
        {
            finished = true;

            Debug.Log("Well Done! The game has ended.");

            // Πάγωμα παιχνιδιού
            Time.timeScale = 0f;
        }
    }
}
