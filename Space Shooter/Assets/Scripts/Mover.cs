using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
	public float velocidad;
	void Start (){
		GetComponent<Rigidbody> ().velocity = transform.forward * velocidad;

	}
}