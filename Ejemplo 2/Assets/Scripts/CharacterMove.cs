using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour {
	
	[SerializeField]
	private float moveSpeed;
	//[SerializeField]
	//private float rotateSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("foward")){
			transform.Translate(transform.forward*moveSpeed*Time.deltaTime);
		}
		if(Input.GetButton("back")){
			transform.Translate(-transform.forward*moveSpeed*Time.deltaTime);
		}
		if(Input.GetButton("left")){
			transform.Translate(-transform.right*moveSpeed*Time.deltaTime);
		}
		if(Input.GetButton("rigth")){
			transform.Translate(transform.right*moveSpeed*Time.deltaTime);
		}
		//transform.Rotate(Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rotateSpeed);
	}
}
