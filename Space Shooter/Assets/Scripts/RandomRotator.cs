using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {

	public float caida;

	void Start() {
		GetComponent<Rigidbody> ().angularVelocity = Random.insideUnitSphere * caida;
	}

}
