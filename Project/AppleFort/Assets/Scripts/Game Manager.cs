using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
   //Canvas
   public TextMeshProUGUI gameOverText;
   public TextMeshProUGUI scoreText;
   public Button restartButton;
   public GameObject titleScreen;
   public TextMeshProUGUI levelCompeteText;
   public Button nextLevel;

   //Tech
   public bool isGameActive;
   public float gravityModifier = 1.0f;
   private int score;

    // Start is called before the first frame update
    void Start()
    {
        SetGravity();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Game Over Method
    public void GameOver()
    {       
      
      gameOverText.gameObject.SetActive(true);
      restartButton.gameObject.SetActive(true);
      isGameActive = false;

    }

    public void SetGravity()
    {
        Physics.gravity = new Vector3(0, -9.81f * gravityModifier, 0);
    }

    public void RestartGame()
    {
        DetectCollisions.seedsCollected = 0; // Reset seeds count
        SetGravity();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);        
    }
    public void StartGame()
    {
        isGameActive = true;
        titleScreen.gameObject.SetActive(false);
    }

    public void NextLevel()
    {
        isGameActive = true;
        DetectCollisions.seedsCollected = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Next Level Loaded");

    }

    public void LevelComplete()
    {
        levelCompeteText.gameObject.SetActive(true);
        nextLevel.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void ReduceScore(int scoreToReduce)
    {
        score -= scoreToReduce;
        scoreText.text = "Score: " + score;
    }
}
