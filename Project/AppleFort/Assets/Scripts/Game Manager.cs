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
   public float gravityModifier = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        SetGravity();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Game Over Method
    public void GameOver()
    {
       if (isGameActive == false) //Should be triggered by dying in the Player Controller Script
        { 
         gameOverText.gameObject.SetActive(true);
         restartButton.gameObject.SetActive(true); 
       }

    }

    public void SetGravity()
    {
        Physics.gravity = new Vector3(0, -9.81f * gravityModifier, 0);
    }

    public void RestartGame()
    {
        SetGravity();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
}
