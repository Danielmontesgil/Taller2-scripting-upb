using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {

    [SerializeField]
    private float coolDown;

    // Use this for initialization
	void Start ()
    {
        coolDown = 0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        coolDown -= Time.deltaTime;

        if (coolDown < 0)
            coolDown = 0;

        if (Input.GetMouseButtonDown(1) || coolDown == 0)
        {
            Vector3 teleportPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = teleportPosition + Vector3.one;
            coolDown = 5;
        }	
	}
}
