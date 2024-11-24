using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TMPro.Examples;

public class Timer : MonoBehaviour
{
    public bool startTimer;
    [SerializeField] TextMeshProUGUI timerText;
    float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        //startTimer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(startTimer == true) 
        { 
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime/60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        int milliseconds = Mathf.FloorToInt((elapsedTime % 1) * 100);

        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
        }
    }
}
