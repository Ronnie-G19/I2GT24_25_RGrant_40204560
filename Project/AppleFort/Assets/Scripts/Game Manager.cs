using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   public TextMeshProUGUI gameOverText;
   public Button restartButton;
   public bool isGameActive;


    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Game Over Method - 
    public void GameOver()
    {
       if (isGameActive == false) //Should be triggered by dying in the Player Controller Script - need to set up text and create button
        { 
         gameOverText.gameObject.SetActive(true);
          restartButton.gameObject.SetActive(true);
       }

    }
}
