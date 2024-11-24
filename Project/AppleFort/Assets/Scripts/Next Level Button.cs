using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TMPro.Examples;

public class NextLevelButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    private Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        timer = GameObject.Find("Canvas").GetComponent<Timer>();
        button.onClick.AddListener(NextLevel);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void NextLevel()
    {

        Debug.Log(button.gameObject.name + "was clicked");
        gameManager.NextLevel();
        timer.startTimer = true;
    }
}
