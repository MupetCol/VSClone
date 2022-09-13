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

	void Update()
	{

	}

	#endregion

	IEnumerator RuneTracerlow()
	{
		while (true)
		{
			for (int i = 0; i < amount; i++)
			{
				RuneTracerProjectile project = Instantiate(_projectile, _spawnPoint.position, Quaternion.identity);
				yield return new WaitForSeconds(projectInverval);
			}
			yield return new WaitForSeconds(cooldown);
		}

	}
	//private Transform DetectClosestEnemy()
	//{

	//	Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, _radius, _enemyLayer);

	//	if (enemies.Length > 0)
	//	{
	//		Transform target = null;

	//		target = enemies[Random.Range(0, enemies.Length)].transform;

	//		return target;
	//	}

	//	return null;

	//	//OnDrawGizmosSelected();
	//}
}
