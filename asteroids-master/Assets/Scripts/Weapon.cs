using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    [SerializeField]
    private Rigidbody bullet;
    [SerializeField]
    private float speed;
    [SerializeField]
    private Transform bulletSpawn;

    void Shoot()
    {
        SpawnBullet();      
    }

    void SpawnBullet()
    {
        Rigidbody spawnedBullet = (Rigidbody)Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        spawnedBullet.velocity = (transform.forward * speed);
    }
}
