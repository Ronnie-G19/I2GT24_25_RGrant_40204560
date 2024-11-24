using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private float timer = 5;
    private float projectileTime;

    public GameObject enemyProjectile;
    public Transform spawnPoint;
    public float enemySpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ShootAtPlayer();
    }

    void ShootAtPlayer()
    {
        projectileTime -= Time.deltaTime;

        if (projectileTime > 0) return;

        projectileTime = timer;

        //Spawning Projectile
        GameObject projectileObj = Instantiate(enemyProjectile, spawnPoint.position, spawnPoint.rotation);
        Rigidbody projectileRig = projectileObj.GetComponent<Rigidbody>();

        //Firing at player
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null && projectileRig != null)
        {
            Vector3 directionToPlayer = (player.transform.position - spawnPoint.position).normalized;
            projectileRig.velocity = directionToPlayer * enemySpeed;

        }
        Destroy(projectileObj, 3f);
    }
}
