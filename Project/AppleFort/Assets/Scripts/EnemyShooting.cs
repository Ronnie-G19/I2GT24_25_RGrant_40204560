using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject enemyProjectile;
    public Transform enemyProjectilePos;

    private float timer;
    private GameObject player;
    private GameManager gameManager;
    private LifeSystem lifeSystem;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = GameObject.FindObjectOfType<GameManager>();
        lifeSystem = GameObject.FindObjectOfType<LifeSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager != null && !gameManager.isGameActive || lifeSystem != null && lifeSystem.dead)
        {
            return; 
        }


        float distance = Vector2.Distance(transform.position, player.transform.position);
        //Debug.Log (distance);

        if (distance < 15) 
        {
            timer += Time.deltaTime;

          if (timer > 3)
          {
                timer = 0;
                shoot();
          }
        } 


    }

    void shoot()
    {
        Instantiate(enemyProjectile, enemyProjectilePos.position, Quaternion.identity);
    }
}
