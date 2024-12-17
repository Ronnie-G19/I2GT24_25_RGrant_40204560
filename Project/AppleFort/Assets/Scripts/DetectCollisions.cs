using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetectCollisions : MonoBehaviour
{
    private GameManager gameManager;
    private AudioSource seedAudio;
    public AudioClip seedClip;
    public static int seedsCollected = 0;
    public int totalSeeds = 6;
    public TextMeshProUGUI seedCountText;
    public int pointValue;

    // Start is called before the first frame update
    void Start()
    {
        UpdateSeedCountUI();
        gameManager = FindObjectOfType<GameManager>();
        seedAudio = GetComponent<AudioSource>();
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

            gameManager.UpdateScore(pointValue);
            UpdateSeedCountUI();
            seedAudio.PlayOneShot(seedClip, 0.5f);
        }
       
    }

    private void UpdateSeedCountUI()
    {
        seedCountText.text = $"{seedsCollected}/{totalSeeds} Seeds Collected";
    }

}
