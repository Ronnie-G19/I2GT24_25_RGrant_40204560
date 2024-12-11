using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetectCollisions : MonoBehaviour
{

    public static int seedsCollected = 0;
    public int totalSeeds = 6;
    public TextMeshProUGUI seedCountText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateSeedCountUI();
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

            UpdateSeedCountUI();
        }
       
    }

    private void UpdateSeedCountUI()
    {
        seedCountText.text = $"{seedsCollected}/{totalSeeds} Seeds Collected";
    }

}
