using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Enemy : MonoBehaviour {

    [SerializeField]
    private float damagePerHit = 10;

    [SerializeField]
    private float lifePoints = 100;

	[SerializeField]
	private Text winText;

	private void Start(){
		winText.text = "";
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Bullet")
        {
            MakeDamage();
            Destroy(collision.gameObject);
        }
    }

    private void MakeDamage()
    {
        lifePoints -= damagePerHit;
        if (lifePoints <= 0)
        {
            Debug.Log("Death");
            Destroy(gameObject);
			winText.text = "You Win!";
        }
    }
}
