using UnityEngine;
using System.Collections;

[System.Serializable]
public class limite
{
	public float xMin, xMax, zMin, zMax;
}


public class ControlesJugador : MonoBehaviour 
{
	public float velocidad;
	public float rotacion;
	public limite Limite;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	private float nextFire;

	void Update ()
	{
		float movimientoH = Input.GetAxis ("Horizontal");
		float movimientoV = Input.GetAxis ("Vertical");

		Vector3 movimiento = new Vector3 (movimientoH, 0.0f, movimientoV);
		GetComponent<Rigidbody> ().velocity = movimiento * velocidad;

		GetComponent<Rigidbody> ().position = new Vector3 
		(
			Mathf.Clamp (GetComponent<Rigidbody> ().position.x, Limite.xMin, Limite.xMax),
			0.0f, 
			Mathf.Clamp (GetComponent<Rigidbody> ().position.z, Limite.zMin, Limite.zMax)
		);

		GetComponent<Rigidbody> ().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -rotacion);

		if (Input.GetMouseButton(0) && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			GetComponent<AudioSource>().Play();
		}
	}
}