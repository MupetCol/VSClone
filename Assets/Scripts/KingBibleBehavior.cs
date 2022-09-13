using UnityEngine;
using System.Collections;

public class KingBibleBehavior : WeaponBase
{
	#region PUBLIC_VARIABLES

	public float _radius;
	public KingBibleProjectile _projectile;
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
		StartCoroutine(KingBibleFlow());
	}

	void Update()
	{

	}

	#endregion

	IEnumerator KingBibleFlow()
	{
		while (true)
		{
			for (int i = 0; i < amount; i++)
			{
				KingBibleProjectile project = Instantiate(_projectile, _spawnPoint.position+Vector3.right, Quaternion.identity,_spawnPoint);
				project.SetValues(speed, _spawnPoint.gameObject, true, area);
				yield return new WaitForSeconds(projectInverval);
			}
			yield return new WaitForSeconds(cooldown);
		}

	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere(transform.position, _radius);
	}
}
