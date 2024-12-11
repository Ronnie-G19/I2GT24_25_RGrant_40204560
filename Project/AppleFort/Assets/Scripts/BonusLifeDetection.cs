using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusLifeDetection : MonoBehaviour
{
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
        if (other.CompareTag("BonusLife"))
        {
            LifeSystem lifeSystem = FindObjectOfType<LifeSystem>();
            if (lifeSystem != null)
            {
                lifeSystem.GainLife();
            }
            Destroy(other.gameObject);
        }
    }
}
