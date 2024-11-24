using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class FinishLine : MonoBehaviour
{
    private GameManager gameManager;
    private Timer timer; //Calling Timer Class


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        timer = GameObject.FindObjectOfType<Timer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player")
        {

            gameManager.LevelComplete();
            timer.StopTimer();
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }


}
