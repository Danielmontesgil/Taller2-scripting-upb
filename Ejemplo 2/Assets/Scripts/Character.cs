using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour {

	[SerializeField]
	private float damagePerHit;

	[SerializeField]
	private float lifePoints;

	[SerializeField]
	private Text loseText;

    private IWeapon[] weapons;
    private int current = 0;

    private void Awake()
    {
        weapons = GetComponents<IWeapon>();
        if (weapons == null)
            Debug.LogWarning("This character doesn't have any weapon.");
    }

	private void Start(){
		loseText.text = "";
	}

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            weapons [current].Shoot();
        if (Input.GetButtonDown("Change Weapon"))
            ChangeWeapon();
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, transform.forward);
    }

    private void ChangeWeapon(int selected)
    {
        current = selected;
        Debug.Log("Changed weapon" + selected);
    }

    private void ChangeWeapon()
    {
        int selected = (current + 1) % weapons.Length;
        ChangeWeapon(selected);
    }

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.tag == "EnemyBullet")
		{
			Debug.Log ("medieron");
			MakeDamage();
			Destroy(collision.gameObject);
		}
	}

	private void MakeDamage(){
		lifePoints -= damagePerHit;
		if (lifePoints <= 0)
		{
			Debug.Log("Death");
			GetComponent<Character>().enabled = false;
			GetComponent<BoxCollider> ().enabled = false;
			loseText.text = "You Lose!";
		}
	}
}
