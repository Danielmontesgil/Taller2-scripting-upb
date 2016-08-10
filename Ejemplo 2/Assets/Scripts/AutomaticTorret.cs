using UnityEngine;
using System.Collections;

public class AutomaticTorret : MonoBehaviour, IWeapon {

	[SerializeField]
	private Rigidbody bullet;

	[SerializeField]
	private float force;

	private float tiempoDisparo;

	public void Start()
	{
		tiempoDisparo = 0f;
	}

	private void Update()
	{
		tiempoDisparo += 1 * Time.deltaTime;
		if (tiempoDisparo >= 1f) {
			Shoot ();
			tiempoDisparo = 0f;
		}
	}

	public virtual void Shoot()
	{
		Rigidbody shot = (Rigidbody)Instantiate(bullet, transform.position + transform.forward * 1f, transform.rotation);
		shot.velocity = transform.forward * force;
	}
}
