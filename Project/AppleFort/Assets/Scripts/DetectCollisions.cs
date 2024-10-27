using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{

    public static int seedsCollected = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Seeds and Enemy destroy on touch
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Seed"))
        {
            Destroy(other.gameObject);
            seedsCollected++;
            Debug.Log("Seed Collected " + seedsCollected);
        }
       
    }


}
