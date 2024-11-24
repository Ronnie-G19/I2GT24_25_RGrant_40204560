using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomMovement : MonoBehaviour
{
    public float speed = 2f;
    public float range = 1f;
    private Vector3 initialPosition;


    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float noiseX = Mathf.PerlinNoise(Time.time * speed, 0) * 2 - 1;
        float noiseY = Mathf.PerlinNoise(0, Time.time * speed) * 2 - 1;

        Vector3 offset = new Vector3(noiseX, noiseY, 0) * range;
        transform.position = initialPosition + offset;
    }
}
