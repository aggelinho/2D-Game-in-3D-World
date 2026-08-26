using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed ; 
    private PlayerController playercontroller; 
    private float leftBound = -15;

    void Start()
    {
        playercontroller = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if(playercontroller.gameOver == false)
        {
          transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
        }

        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle") )
        {
            Destroy(gameObject);
        }   
    }
}
