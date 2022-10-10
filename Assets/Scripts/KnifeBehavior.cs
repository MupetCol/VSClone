using UnityEngine;
using System.Collections;

public class KnifeBehavior : WeaponBase, ILevelUp<float>
{
	#region PUBLIC_VARIABLES

	public KnifeProjectile _projectile;
	public Transform _spawnPoint;
	public float _offset = .1f;
	public Vector3 _dir = Vector3.right;
	public bool _resDir = false;



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
		if (Input.GetKey(KeyCode.W))
		{
			if (!_resDir)
			{
				_resDir = true;
				_dir = Vector3.zero;
			}
			_dir += Vector3.up;
		}

		if (Input.GetKey(KeyCode.A))
		{
			if (!_resDir)
			{
				_resDir = true;
				_dir = Vector3.zero;
			}
			_dir += Vector3.left;
		}

		if (Input.GetKey(KeyCode.S))
		{
			if (!_resDir)
			{
				_resDir = true;
				_dir = Vector3.zero;
			}
			_dir += Vector3.down;
		}

		if (Input.GetKey(KeyCode.D))
		{
			if (!_resDir)
			{
				_resDir = true;
				_dir = Vector3.zero;
			}
			_dir += Vector3.right;
		}

		_resDir = false;
	}

	#endregion

	IEnumerator KnifeFlow()
	{
		while (true)
		{
			Vector3 tempDir = _dir;
			tempDir.Normalize();
			
			for (int i = 0; i < amount + _weaponStats.globalAmount.Value; i++)
			{
				KnifeProjectile project = Instantiate(_projectile, _spawnPoint.position + 
					new Vector3(Random.Range(-_offset, _offset), Random.Range(-_offset,_offset),0), Quaternion.identity);
				project.SetDirection(tempDir, speed* _weaponStats.globalSpeed.Value);
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
				amount++;
				baseDamage++;
				break;

			case 4:
				amount++;
				break;

			case 5:
				pierce++;
				break;

			case 6:
				amount++;
				break;

			case 7:
				amount++;
				baseDamage++;
				break;

			case 8:
				pierce++;
				_reachedMaxLevel = true;
				if (Utilities.Instance._ownedObjects.Contains(this.gameObject))
				{
					Utilities.Instance._ownedObjects.Remove(this.gameObject);
				}
				break;
		}
	}
}
