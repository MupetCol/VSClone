using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Random = UnityEngine.Random;

public class LightingRingBehavior : WeaponBase
{
	#region PUBLIC_VARIABLES


	#endregion

	#region PRIVATE_VARIABLES

	private Collider2D _collider;
	private LayerMask _enemyLayer;


	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES

	[SerializeField] private GameObject _lightingVisual;

	#endregion

	#region UNITY_METHODS

	public override void  Awake()
	{
		base.Awake();
		_collider = GetComponent<Collider2D>();
	}

	void Start()
	{
		_enemyLayer = LayerMask.GetMask("Enemies");
		StartCoroutine(LightingRingFlow());
	}

	protected IEnumerator LightingRingFlow()
	{
		ContactFilter2D filter = new ContactFilter2D();
		filter.SetLayerMask(_enemyLayer);
		

		while (true)
		{
			List<Collider2D> colliders = new List<Collider2D>();
			Physics2D.OverlapCollider(_collider, filter, colliders);

			if (colliders.Count > 0)
			{
				for (int i = 0; i < _weaponStats.amount + _weaponStats.globalAmount.Value; i++)
				{
					int index = Random.Range(0, colliders.Count);
					var col = colliders[index];
					if (col != null)
					{
						Instantiate(_lightingVisual, col.transform.position, Quaternion.identity);
						col.GetComponent<IDamageable<float, float>>().Damage(_weaponStats.baseDamage * _weaponStats.globalMight.Value
							, _weaponStats.knockBack);
					}
					yield return new WaitForSeconds(_weaponStats.hitboxDelay);
				}
			}

			yield return new WaitForSeconds(_weaponStats.cooldown * _weaponStats.globalCooldown.Value);
			colliders.Clear();
		}
	}



	#endregion

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
				area++;
				baseDamage += 10;
				break;

			case 4:
				amount++;
				break;

			case 5:
				area++;
				baseDamage += 20;
				break;

			case 6:
				amount++;
				break;

			case 7:
				area++;
				baseDamage += 20;
				break;

			case 8:
				amount++;
				_reachedMaxLevel = true;
				if (Utilities.Instance._ownedObjects.Contains(this.gameObject))
				{
					Utilities.Instance._ownedObjects.Remove(this.gameObject);
				}
				break;
		}
	}
}
