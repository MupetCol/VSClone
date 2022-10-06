using UnityEngine;
using System.Collections;

public class NdujaFritaTantoBehavior : WeaponBase
{
	#region PUBLIC_VARIABLES

	public NdujaProjectile _projectile;
	public Transform _spawnPoint;
	public float _offsetDivider = 5f;

	#endregion

	#region PRIVATE_VARIABLES

	private float _timer;
	private LayerMask _enemyLayer;

	#endregion

	#region UNITY_METHODS
	public override void Awake()
	{
		base.Awake();
		_enemyLayer = LayerMask.GetMask("Enemies");
	}

	public void Activate()
	{
		StartCoroutine(NdujaFlow());
	}

	private void OnDisable()
	{
		StopCoroutine(NdujaFlow());
	}

	#endregion

	IEnumerator NdujaFlow()
	{
		_timer = 0;
					
		while (_timer < duration)
		{
			Vector3 dir = Vector3.zero;
			_timer += projectInverval;
			bool changeX = false;
			int offset = 0;
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

			if (dir == Vector3.zero)
			{
				dir = Vector3.right;
			}
			else
			{
				dir.Normalize();
			}

			if(dir == Vector3.up || dir == Vector3.down)
			{
				changeX = true;
			}
			
			for (int i = 0; i < 3; i++)
			{
				NdujaProjectile project = Instantiate(_projectile, _spawnPoint.position, Quaternion.identity);
				project.GetComponent<WeaponDealDamage>()._weapon = this;

				if (offset == 2) offset = -1;
				project.SetDirection(dir, speed,offset / _offsetDivider, changeX);
	
				if (i % 3 == 2) yield return new WaitForSeconds(.1f);
				offset++;
			}
			yield return new WaitForSeconds(projectInverval);
		}

	}

	private void Update()
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

		if (dir == Vector3.zero)
		{
			dir = Vector3.right;
		}
		else
		{
			dir.Normalize();
		}
	}
}
