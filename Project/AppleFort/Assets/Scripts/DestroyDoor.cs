using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDoor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DetectCollisions.seedsCollected >= 6)
        {

            GameObject door = GameObject.FindGameObjectWithTag("Door");
            Debug.Log("Door Opened!");
           
            if (door != null)
            {

                Destroy(door);

            }

        }
    }
}
