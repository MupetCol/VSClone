using UnityEngine;
using System.Collections;

public class RuneTracerBehavior : WeaponBase
{
	#region PUBLIC_VARIABLES

	public RuneTracerProjectile _projectile;
	public Transform _spawnPoint;

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
		StartCoroutine(RuneTracerlow());
	}

	#endregion

	IEnumerator RuneTracerlow()
	{
		while (true)
		{
			for (int i = 0; i < amount + _weaponStats.globalAmount.Value; i++)
			{
				RuneTracerProjectile project = Instantiate(_projectile, _spawnPoint.position, Quaternion.identity);
				yield return new WaitForSeconds(projectInverval);
			}
			yield return new WaitForSeconds(cooldown/ _weaponStats.globalCooldown.Value);
		}

	}
}
