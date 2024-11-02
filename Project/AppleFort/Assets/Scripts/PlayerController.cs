using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Tech
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    //Movement
    private float horizontalInput;
    public float speed = 10f;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver;

    //Boundaries
    private float xRange = 13f;
    private float rightBoundary = 189f;

    //Objects
    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {

        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (DetectCollisions.seedsCollected == 6)
        {
            OpenDoor();
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


    void OpenDoor()
    {
        if (door != null)
        {

            door.SetActive(false);
            Debug.Log("Door opened!");
        }


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
            Squashed squashedScript = collision.gameObject.GetComponentInChildren<Squashed>();
            if (squashedScript != null && !squashedScript.isSquashed)

            {

                Debug.Log("Game Over");
                gameOver = true;
                playerAnim.SetBool("Death_b", true);
                playerAnim.SetInteger("DeathType_int", 1);
                explosionParticle.Play();
                dirtParticle.Stop();
                playerAudio.PlayOneShot(crashSound, 1.0f);

            }
            else
            {
                Debug.Log("landed on squshed enemy");

            }
        }
    }

}
