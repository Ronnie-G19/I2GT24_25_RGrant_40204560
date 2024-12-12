using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystem : MonoBehaviour
{
    public GameObject[] lives;
    public int maxLives = 6;
    public int startingLives = 3;
    public int life;
    public bool dead;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        life = startingLives;

        for (int i = 0; i < lives.Length; i++)
        {
            if (i < startingLives)
            {
                lives[i].SetActive(true);
            }
            else
            {
                lives[i].SetActive(false);
            }
        }
    }



    // Update is called once per frame
    void Update()
    {
        if (dead && gameManager != null)
        {
            gameManager.GameOver();
        }
    }

    public void TakeDamage(int d)
    {
        life -= d;
        if (life >= 0 && life < lives.Length)
        {
            lives[life].SetActive(false); 
        }
        if (life == 0)
        {
            dead = true;
        }
    }

    public void GainLife()
    {
        if (life < maxLives)
        {

            for (int i = 0; i < lives.Length; i++)
            {
                if (!lives[i].activeInHierarchy)
                {
                    lives[i].SetActive(true);
                    life++;
                    Debug.Log("Life Gained. Life is now:" + life);
                    break;                  
                }
            }
        }
    }
}
