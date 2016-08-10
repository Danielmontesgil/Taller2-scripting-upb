using UnityEngine;
using System.Collections;

public class RotationTorret : MonoBehaviour {
	
	void Update () {
		transform.Rotate (new Vector3 (0, 20, 0) * Time.deltaTime);
	}
}
