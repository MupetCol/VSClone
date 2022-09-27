using UnityEngine;
using System.Collections;

public class BreathCoolBehavior : WeaponBase
{
	#region PUBLIC_VARIABLES

	public GameObject _projectile;
	public Transform _spawnPoint;
	private float _timer;

	#endregion

	#region PRIVATE_VARIABLES

	#endregion

	#region UNITY_METHODS

	void Start()
	{
		StartCoroutine(BreathCoolFlow());
	}

	#endregion

	IEnumerator BreathCoolFlow()
	{
		while (true)
		{
			_timer = 0;

			while(_timer < duration)
			{
				_timer += _weaponStats.projectInverval;

				Instantiate(_projectile, _spawnPoint.position, Quaternion.identity);
				yield return new WaitForSeconds(_weaponStats.projectInverval);
			}
			yield return new WaitForSeconds((cooldown+duration) / _weaponStats.globalCooldown.Value);
		}
	}

}
