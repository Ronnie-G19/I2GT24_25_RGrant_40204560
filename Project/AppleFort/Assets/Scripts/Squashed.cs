using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squashed : MonoBehaviour
{
    public bool isSquashed = false;
    private GameManager gameManager;
    public int pointValue;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player" && !isSquashed)

        {
            isSquashed = true;

            gameManager.PlayAntDeathSound();

            foreach (Transform child in transform) { 
                child.gameObject.SetActive(false);
            }
            Destroy(transform.parent.gameObject);
            Debug.Log("Enemy squashed!");

            gameManager.UpdateScore(pointValue);
        }
    }   
}
