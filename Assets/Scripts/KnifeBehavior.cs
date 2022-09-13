using UnityEngine;
using System.Collections;

public class KnifeBehavior : WeaponBase
{
	#region PUBLIC_VARIABLES

	public KnifeProjectile _projectile;
	public Transform _spawnPoint;
	public float _offset = .1f;



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
		StartCoroutine(KnifeFlow());
	}

	void Update()
	{

	}

	#endregion

	IEnumerator KnifeFlow()
	{
		while (true)
		{
			for (int i = 0; i < amount; i++)
			{
				Vector3 dir = Vector3.zero;
				if (Input.GetKey(KeyCode.W))
				{
					dir += Vector3.up;
				}

				if (Input.GetKey(KeyCode.A))
				{
					dir += Vector3.left;
				}

				if (Input.GetKey(KeyCode.S))
				{
					dir += Vector3.down;
				}

				if (Input.GetKey(KeyCode.D))
				{
					dir += Vector3.right;
				}

				if(dir == Vector3.zero)
				{
					dir = Vector3.right;
				}
				else
				{
					dir.Normalize();
				}

				KnifeProjectile project = Instantiate(_projectile, _spawnPoint.position + 
					new Vector3(Random.Range(-_offset, _offset), Random.Range(-_offset,_offset),0), Quaternion.identity);
				project.SetDirection(dir, speed);

				yield return new WaitForSeconds(projectInverval);
			}
			yield return new WaitForSeconds(cooldown);
		}

	}
}
