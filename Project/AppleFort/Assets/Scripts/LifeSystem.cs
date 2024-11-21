using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystem : MonoBehaviour
{
    public GameObject[] lives;
    public int life;
    public bool dead;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>();
    }



    // Update is called once per frame
    void Update()
    {
        if (dead == true)
        {
            gameManager.GameOver();
        }
    }

    public void TakeDamage(int d)
    {
        life -= d;
        Destroy(lives[life].gameObject);
        if(life < 1)
        {
            dead = true;
        }
    }
}
