using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    public int targetPoint;
    public float speed;
    public AudioSource source;
    public AudioClip antMovement;

    private float timeUntilNextSound;
    private float minTimeBetweenSound = 5f;
    private float maxTimeBetweenSounds = 30f;

    // Start is called before the first frame update
    void Start()
    {
        targetPoint = 0;
        SetNextSoundTime();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == patrolPoints[targetPoint].position)
        {

            IncreaseTargetInt();
        }


        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);

        HandleMovementSound();
    }

    void IncreaseTargetInt()
    {

        targetPoint++;
        if (targetPoint >= patrolPoints.Length)
        {

            targetPoint = 0;
        }
    }

    void HandleMovementSound()
    {
        if (timeUntilNextSound <= 0f)
        {
            if (!source.isPlaying)
            {
                source.PlayOneShot(antMovement);
                Debug.Log($"Sound played by {gameObject.name} at {Time.time}");
                SetNextSoundTime();
            }
        }
        else
        {
            timeUntilNextSound -= Time.deltaTime;
        }
    }
    

    void SetNextSoundTime()
    {

        timeUntilNextSound = Random.Range(minTimeBetweenSound, maxTimeBetweenSounds);
    }
}


