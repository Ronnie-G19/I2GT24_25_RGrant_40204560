using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squashed : MonoBehaviour
{
    public bool isSquashed = false;

    // Start is called before the first frame update
    void Start()
    {

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
            foreach (Transform child in transform) { 
                child.gameObject.SetActive(false);
            }
            Destroy(transform.parent.gameObject);
            Debug.Log("Enemy squashed!");
        }
    }   
}
