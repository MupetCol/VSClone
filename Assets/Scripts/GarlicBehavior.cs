using UnityEngine;
using System.Collections;

public class GarlicBehavior : WeaponBase
{

	#region PRIVATE_VARIABLES

	private bool _canDealDamage = true;
	private float _lastArea;

	#endregion

	#region UNITY_METHODS
	public override void Awake()
	{
		base.Awake();
		UpdateArea();
	}

	void UpdateArea()
	{
		transform.localScale *= _weaponStats.area * _weaponStats.globalArea.Value;
		_lastArea = _weaponStats.area + _weaponStats.globalArea.Value;
	}


	#endregion

	public IEnumerator DealDamage(Collision2D coll)
	{
		_canDealDamage = false;
		yield return new WaitForSeconds(hitboxDelay);
		_canDealDamage = true;
	}

	private void Update()
	{
		if(_weaponStats.area + _weaponStats.globalArea.Value != _lastArea)
		{
			UpdateArea();
		}
	}

	public override void LevelUp()
	{
		if (_reachedMaxLevel)
		{
			Debug.Log("Shouldn't have been called, already max level");
		}

		base.LevelUp();
		switch (_currentLevel)
		{
			case 2:
				area += .4f;
				baseDamage += 2;
				break;

			case 3:
				cooldown -= .1f;
				baseDamage += 1;
				break;

			case 4:
				area += .2f;
				baseDamage += 1;
				break;

			case 5:
				cooldown -= .1f;
				baseDamage += 2;
				break;

			case 6:
				area += .2f;
				baseDamage += 1;
				break;

			case 7:
				cooldown -= .1f;
				baseDamage += 1;
				break;

			case 8:
				area += .2f;
				baseDamage += 1;
				_reachedMaxLevel = true;
				if (Utilities.Instance._ownedObjects.Contains(this.gameObject))
				{
					Utilities.Instance._ownedObjects.Remove(this.gameObject);
				}
				break;
		}
	}
}
