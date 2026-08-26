using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody Rb;
    public float jump;
    public float gravity;
    private Vector3 defaultGravity;
    public bool isOnGround = true;
    public bool gameOver = false;
    private Animator playerAnimation;
    private AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public int hitsToLose = 3;
    public int hitCount = 0;

    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        playerAnimation = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        defaultGravity = Physics.gravity;
        Physics.gravity = defaultGravity * gravity;    
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            Rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            isOnGround = false; 
            playerAnimation.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound);
        }
    }

    private void OnCollisionEnter(Collision Collision) 
    {
        if(Collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (Collision.gameObject.CompareTag("Obstacle"))  
        {
            gameOver = true;
            Debug.Log("Game Over!");
            playerAudio.PlayOneShot(crashSound);
            playerAnimation.SetBool("Death_b",true);
            playerAnimation.SetInteger("DeathType_int",1);
        }
        else if (Collision.gameObject.CompareTag("Enemy"))
        {
            RegisterEnemyHit();
        }
    }

    private void RegisterEnemyHit()
    {
        hitCount++;
        Debug.Log($"Enemy hit: {hitCount}/{hitsToLose}");
        playerAudio.PlayOneShot(crashSound);

        if (hitCount >= hitsToLose)
        {
            TriggerGameOver();
        }
    }

    private void TriggerGameOver()
    {
        gameOver = true;
        Debug.Log("Game Over!");
        playerAnimation.SetBool("Death_b", true);
        playerAnimation.SetInteger("DeathType_int", 1);
    }    
}
