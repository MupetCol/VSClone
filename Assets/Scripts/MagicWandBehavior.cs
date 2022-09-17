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
}
