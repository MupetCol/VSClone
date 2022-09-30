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

	public override void LevelUp()
	{
		if (_reachedMaxLevel)
		{
			Debug.Log("Shouldn't have been called, already max level");
		}

		base.LevelUp();
		switch (_currentLevel)
		{
			case 2:
				amount++;
				area += .2f;
				break;

			case 3:
				baseDamage += 10;
				duration +=.5f;
				break;

			case 4:
				amount++;
				area += .2f;
				break;

			case 5:
				baseDamage += 10;
				duration += .3f;
				break;

			case 6:
				amount++;
				area += .2f;
				break;

			case 7:
				baseDamage += 5;
				duration += .3f;
				break;

			case 8:
				baseDamage += 5;
				area += .2f;
				_reachedMaxLevel = true;
				if (Utilities.Instance._ownedObjects.Contains(this.gameObject))
				{
					Utilities.Instance._ownedObjects.Remove(this.gameObject);
				}
				break;
		}
	}

}
