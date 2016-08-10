using UnityEngine;

public class Gun : MonoBehaviour, IWeapon {

    [SerializeField]
    private int capacity = 10;

    [SerializeField]
    private Rigidbody bullet;

    [SerializeField]
    private float force;

    private int ammo;

    private void Start()
    {
        Reload();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Reload"))
            Reload();
    }

    public virtual void Shoot()
    {
        if (ammo > 0)
        {
            ammo--;
            SpawnBullet();
        }
    }

    private void Reload()
    {
        ammo = capacity;
    }

    private void SpawnBullet()
    {
        Rigidbody shot = (Rigidbody)Instantiate(bullet, transform.position + transform.forward * 1f, transform.rotation);
        shot.velocity = transform.forward * force;
    }
}
