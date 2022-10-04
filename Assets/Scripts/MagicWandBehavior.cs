using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MagicWandBehavior : WeaponBase
{
	#region PUBLIC_VARIABLES

	public float _radius;
	public MagicWandProjectile _projectile;
	public Transform _spawnPoint;

	#endregion

	#region PRIVATE_VARIABLES

	private LayerMask _enemyLayer;

	#endregion

	#region UNITY_METHODS
	public override void Awake()
	{
		base.Awake();
		_enemyLayer = LayerMask.GetMask("Enemies");
		//StartCoroutine(InitLevelUp());
		
	}
	void Start()
    {
		StartCoroutine(MagicWandFlow());
	}


	#endregion

	IEnumerator MagicWandFlow()
	{
		while (true)
		{
			for (int i = 0; i < amount + _weaponStats.globalAmount.Value; i++)
			{
				MagicWandProjectile project = Instantiate(_projectile, _spawnPoint.position, Quaternion.identity);
				project.SetDirection(DetectClosestEnemy());
				yield return new WaitForSeconds(_weaponStats.projectInverval);
			}
			yield return new WaitForSeconds(cooldown / _weaponStats.globalSpeed.Value);
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere(transform.position, _radius);
	}
	private Transform DetectClosestEnemy()
	{

		Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, _radius, _enemyLayer);

		if (enemies.Length > 0)
		{
			float distance = 10000f;
			Transform target = null;

			foreach (Collider2D enemy in enemies)
			{
				if (Vector3.Distance(transform.position, enemy.transform.position) < distance)
				{
					target = enemy.transform;
				}
			}

			return target;
		}

		return null;

		//OnDrawGizmosSelected();
	}

	public override void LevelUp(int level)
	{
		if (_reachedMaxLevel)
		{
			Debug.Log("Shouldn't have been called, already max level");
		}

		base.LevelUp(level);
		switch (level)
		{
			case 2:
				amount++;
				break;

			case 3:
				cooldown -= .2f; //should rest .2seconds, not percent based
				break;

			case 4:
				amount++;
				break;

			case 5:
				baseDamage += 10;
				break;

			case 6:
				amount++;
				break;

			case 7:
				pierce++;
				break;

			case 8:
				baseDamage += 10;
				_reachedMaxLevel = true;
				if (Utilities.Instance._ownedObjects.Contains(this.gameObject))
				{
					Utilities.Instance._ownedObjects.Remove(this.gameObject);
				}
				break;
			default:
				break;
		}
	}
}
