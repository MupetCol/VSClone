using UnityEngine;
using System.Collections;

public class SantaWaterBehavior : WeaponBase
{
	#region PUBLIC_VARIABLES

	public GameObject _projectile;

	#endregion

	#region PRIVATE_VARIABLES


	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES

	[SerializeField] private float _radius;

	#endregion

	#region UNITY_METHODS

	void Start()
	{
		StartCoroutine(SantaWaterFlow());
	}

	#endregion

	IEnumerator SantaWaterFlow()
	{
		while (true)
		{
			for (int i = 0; i < amount + _weaponStats.globalAmount.Value; i++)
			{
				Instantiate(_projectile, 
					new Vector3(Random.Range(-transform.position.x, transform.position.x +_radius), 
						Random.Range(-transform.position.y, transform.position.y + _radius), 0), Quaternion.identity);
				yield return new WaitForSeconds(projectInverval);
			}
			yield return new WaitForSeconds(cooldown / _weaponStats.globalCooldown.Value);
		}

	}

}
