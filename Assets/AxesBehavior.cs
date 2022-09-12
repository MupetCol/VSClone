using UnityEngine;
using System.Collections;

public class AxesBehavior : WeaponBase
{
	#region PUBLIC_VARIABLES

	public AxeProjectile _projectile;
	public Transform _spawnPoint;
	public float _axeForce = 10f;

	#endregion

	#region PRIVATE_VARIABLES

	private LayerMask _enemyLayer;

	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS
	public override void Awake()
	{
		base.Awake();
		_enemyLayer = LayerMask.GetMask("Enemies");
	}
	void Start()
	{
		StartCoroutine(AxeFlow());
	}

	#endregion

	IEnumerator AxeFlow()
	{
		while (true)
		{
			for (int i = 0; i < amount; i++)
			{
				AxeProjectile project = Instantiate(_projectile, _spawnPoint.position, Quaternion.identity);

				project.SetDirection(i+1,_axeForce);
				yield return new WaitForSeconds(.2f);
			}
			yield return new WaitForSeconds(cooldown);
		}

	}
}
