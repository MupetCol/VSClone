using UnityEngine;
using System.Collections;

public class RuneTracerBehavior : WeaponBase, ILevelUp<float>
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
				project.GetComponent<WeaponDealDamage>()._weapon = this;
				yield return new WaitForSeconds(projectInverval);
			}
			yield return new WaitForSeconds(cooldown/ _weaponStats.globalCooldown.Value);
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
				baseDamage += 5;
				speed += .2f;
				break;

			case 3:
				baseDamage += 5;
				duration += .3f;
				break;

			case 4:
				amount++;
				break;

			case 5:
				baseDamage += 5;
				speed += .2f;
				break;

			case 6:
				baseDamage += 5;
				duration += .3f;
				break;

			case 7:
				amount++;
				break;

			case 8:
				duration += .5f;
				_reachedMaxLevel = true;
				if (Utilities.Instance._ownedObjects.Contains(this.gameObject))
				{
					Utilities.Instance._ownedObjects.Remove(this.gameObject);
				}
				break;
		}
	}
}
