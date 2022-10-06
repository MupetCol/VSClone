using UnityEngine;
using System.Collections;

public class FireWandBehavior : WeaponBase, ILevelUp<float>
{
	#region PUBLIC_VARIABLES

	public float _radius;
	public FireWandProjectile _projectile;
	public Transform _spawnPoint;
	public float _offsetDivider = 5f;

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
	private void Start()
	{
		StartCoroutine(FireWandFlow());
	}

	#endregion

	IEnumerator FireWandFlow()
	{
		while (true)
		{
			var closestEnemy = DetectClosestEnemy();
			var alternative = transform.position + (Vector3)UnityEngine.Random.insideUnitCircle;
			int offset = 0;
			for (int i = 0; i < amount + _weaponStats.globalAmount.Value; i++)
			{
				FireWandProjectile project = Instantiate(_projectile, _spawnPoint.position, Quaternion.identity);
				project.GetComponent<WeaponDealDamage>()._weapon = this;

				if (offset == 3) offset = 0;

				if(closestEnemy == null)
				{
					
					project.SetDirection(alternative, offset / _offsetDivider);
				}
				else
				{
					project.SetDirection(closestEnemy.position, offset / _offsetDivider);
				}
				if (i % 3 == 2) yield return new WaitForSeconds(_weaponStats.projectInverval);
				offset++;
			}
			yield return new WaitForSeconds(cooldown/_weaponStats.globalCooldown.Value);
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
			Transform target = null;

			target = enemies[Random.Range(0, enemies.Length)].transform;

			return target;
		}

		return null;

		//OnDrawGizmosSelected();
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
				baseDamage += 10;
				break;

			case 3:
				baseDamage += 10;
				speed += .2f;
				break;

			case 4:
				baseDamage += 10;
				break;

			case 5:
				baseDamage += 10;
				speed += .2f;
				break;

			case 6:
				baseDamage += 10;
				break;

			case 7:
				baseDamage += 10;
				speed += .2f;
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
