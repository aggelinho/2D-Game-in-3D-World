using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private bool finished = false;

    private void OnTriggerEnter(Collider other)
    {
        if (finished) return;

        if (other.CompareTag("Player"))
        {
            finished = true;

            Debug.Log("Well Done! Loading Level 2...");

            // Reset timeScale and gravity
            Time.timeScale = 1f;
            Physics.gravity = new Vector3(0, -9.81f, 0);

            // Φόρτωση επόμενης σκηνής
            SceneManager.LoadScene("Level2");
        }
    }
}
