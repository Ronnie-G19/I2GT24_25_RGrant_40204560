using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Tech
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;
    private GameManager gameManager; //Calling Game Manager Class
    private LifeSystem lifeSystem; //Calling Life System Class
    private Timer timer; //Calling Timer Class
    private Vector3 originalGravity; //Setting Gravity
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private bool damageCooldown = false;
    private float damageCooldownDuration = 2.0f;
    public int pointValue;

    //Movement
    private float horizontalInput;
    public float speed = 10f;
    public float jumpForce = 10f;
    public bool isOnGround = true;
    public bool gameOver;

    //Boundaries
    private float xRange = 13f;
    private float rightBoundary = 189f;

    // Start is called before the first frame update
    void Start()
    {

        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
        lifeSystem = GameObject.FindObjectOfType<LifeSystem>();
        timer = GameObject.FindObjectOfType<Timer>();
    }

    // Update is called once per frame
    void Update()
    { 

        //Allow player movement if game is active
        if(gameManager != null && !gameManager.isGameActive)
        {
            return;
        }

        //Checking for Game Over to stop movement
        if (gameOver)
        {
            return;
        }


        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
        

        //Keeping Player Contained
        //Left
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        //Right
        if (transform.position.x > rightBoundary)
        {
            transform.position = new Vector3(rightBoundary, transform.position.y, transform.position.z);

        }

        //Movement
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * horizontalInput);
    }


    //Collision into Enemies = death unless Squashed
    private void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.CompareTag("Ground"))
        {

            isOnGround = true;
            dirtParticle.Play();

        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            if (damageCooldown) return;

            //Does enemy have squash script?
            Squashed squashedScript = collision.gameObject.GetComponentInChildren<Squashed>();

            //If the enemy has a Squashed script and is not squashed,trigger Damage Taken 
            if (squashedScript != null && !squashedScript.isSquashed)
            {
                DamageTaken();

            }
             if (lifeSystem.dead==true)
             { 
                RanOutOfLives();
             }
            }


    }
    public void DamageTaken()
    {
        damageCooldown = true;
        Invoke(nameof(ResetDamageCooldown), damageCooldownDuration);

        Debug.Log("Damage Taken");
        lifeSystem.TakeDamage(1);
        explosionParticle.Play();
        dirtParticle.Stop();
        playerAudio.PlayOneShot(crashSound, 1.0f);
        gameManager.ReduceScore(pointValue);

    }

    public void RanOutOfLives()
    {
        Debug.Log("Game Over");
        gameOver = true;
        playerAnim.SetBool("Death_b", true);
        playerAnim.SetInteger("DeathType_int", 1);
        dirtParticle.Stop();
        timer.StopTimer();
        explosionParticle.Play();
        playerAudio.PlayOneShot(crashSound, 1.0f);
    }

    private void ResetDamageCooldown()
    {
        damageCooldown = false;
    }



}


