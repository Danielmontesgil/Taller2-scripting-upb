using UnityEngine;
using System.Collections;

namespace Asteroids
{
    public class Aiming : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody bullet;
        [SerializeField]
        private float speed;
        [SerializeField]
        private Transform bulletSpawn;

        private void Update()
        {
            Vector3 direction = GetMouseAiming();
			transform.rotation = Quaternion.LookRotation (direction);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
            }
        }

		private void OnDrawGizmos ()
		{
			Debug.DrawRay (transform.position, transform.forward);
		}

        private Vector3 GetMouseAiming()
        {
			Vector3 mouse = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			mouse.z = transform.position.z;
            Vector3 mouseDirection = (mouse - transform.position).normalized;
			return mouseDirection;
        }

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
}