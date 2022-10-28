using UnityEngine;
using System.Collections;

public class KingBibleBehavior : WeaponBase, ILevelUp<float>
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
				KingBibleProjectile project = Instantiate(_projectile, _spawnPoint.position+Vector3.right+Vector3.forward, Quaternion.identity,_spawnPoint);
				project.SetValues(_spawnPoint.gameObject, true);
				project.GetComponent<WeaponDealDamage>()._weapon = this;
				yield return new WaitForSeconds(projectInverval);
			}
			yield return new WaitForSeconds(cooldown/_weaponStats.globalCooldown.Value);
		}

	}

	public void LevelUp(float level)
	{
		_currentLevel++;
		if (_reachedMaxLevel)
		{
			Debug.Log("Shouldn't have been called, already max level");
		}

		switch (level)
		{
			case 2:
				amount++;
				break;

			case 3:
				speed += .3f;
				area += .25f;
				break;

			case 4:
				duration += .5f;
				baseDamage += 10;
				break;

			case 5:
				amount++;
				break;

			case 6:
				speed += .3f;
				area += .25f;
				break;

			case 7:
				duration += .5f;
				baseDamage += 10;
				break;

			case 8:
				amount++;
				if (Utilities.Instance._ownedObjects.Contains(this.gameObject))
				{
					Utilities.Instance._ownedObjects.Remove(this.gameObject);
				}
				break;
		}
	}
}
