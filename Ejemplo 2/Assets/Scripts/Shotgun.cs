using UnityEngine;

public class Shotgun : Gun {
	[SerializeField]
	private int cargador;

	public override void Shoot()
	{
		for (int i = 0; i < cargador; i++)
			base.Shoot();
	}
}

