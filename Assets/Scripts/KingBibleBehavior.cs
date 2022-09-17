using UnityEngine;
using System.Collections;

public class KingBibleBehavior : WeaponBase
{
	#region PUBLIC_VARIABLES

	public float _radius;
	public KingBibleProjectile _projectile;
	public Transform _spawnPoint;

	#endregion

	#region UNITY_METHODS

	void Start()
	{
		StartCoroutine(KingBibleFlow());
	}

	#endregion

	IEnumerator KingBibleFlow()
	{
		while (true)
		{
			for (int i = 0; i < amount + _weaponStats.globalAmount.Value; i++)
			{
				KingBibleProjectile project = Instantiate(_projectile, _spawnPoint.position+Vector3.right, Quaternion.identity,_spawnPoint);
				project.SetValues(speed * _weaponStats.globalSpeed.Value, _spawnPoint.gameObject, true);
				yield return new WaitForSeconds(projectInverval);
			}
			yield return new WaitForSeconds(cooldown/_weaponStats.globalCooldown.Value);
		}

	}
}
