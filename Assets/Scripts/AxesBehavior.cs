using UnityEngine;
using System.Collections;

public class AxesBehavior : WeaponBase
{
	#region PUBLIC_VARIABLES

	public AxeProjectile _projectile;
	public Transform _spawnPoint;
	public float _axeForce = 10f;

	#endregion

	#region UNITY_METHODS

	void Start()
	{
		StartCoroutine(AxeFlow());
	}

	#endregion

	IEnumerator AxeFlow()
	{
		while (true)
		{
			for (int i = 0; i < amount + _weaponStats.globalAmount.Value; i++)
			{
				AxeProjectile project = Instantiate(_projectile, _spawnPoint.position, Quaternion.identity);
				project.GetComponent<WeaponDealDamage>()._weapon = this;

				project.SetDirection(i+1,_axeForce *speed*_weaponStats.globalSpeed.Value);
				yield return new WaitForSeconds(projectInverval);
			}
			yield return new WaitForSeconds(cooldown/_weaponStats.globalCooldown.Value);
		}

	}
}
