using UnityEngine;
using System.Collections;

public class GarlicBehavior : WeaponBase, ILevelUp<float>
{

	#region PRIVATE_VARIABLES

	private float _lastArea;
	private float _startScale;

	#endregion

	#region UNITY_METHODS
	public override void Awake()
	{
		base.Awake();
		_startScale = transform.localScale.x;
	}

	void UpdateArea()
	{
		_lastArea = _startScale + area + _weaponStats.globalArea.Value;
		transform.localScale = new Vector3(_startScale * area * _weaponStats.globalArea.Value,
			_startScale * area * _weaponStats.globalArea.Value,
			_startScale * area * _weaponStats.globalArea.Value);
	}


	#endregion

	private void Update()
	{
		if((area + _weaponStats.globalArea.Value) != _lastArea)
		{
			UpdateArea();
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
