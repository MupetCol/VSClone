using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WhipBehavior : WeaponBase
{
	private float _lastArea;

	#region UNITY_METHODS

	void Start()
	{
		StartCoroutine(WhipFlow());
		_lastArea = _weaponStats.area + _weaponStats.globalArea.Value;
	}

	IEnumerator WhipFlow()
	{
		while (true)
		{
			if (_lastArea != _weaponStats.area + _weaponStats.globalArea.Value)
			{
				for (int i = 0; i < transform.childCount; i++)
				{
					transform.GetChild(i).localScale *= _weaponStats.area * _weaponStats.globalArea.Value;
					_lastArea = _weaponStats.area + _weaponStats.globalArea.Value;		
				}
			}
				

			for (int i = 0; i < amount + _weaponStats.globalAmount.Value; i++)
			{
				int childs = Mathf.Clamp(i, 0, 3);
				var child = transform.GetChild(childs);

				//Set scale if global area stat has changed
				if(_lastArea != _weaponStats.area + _weaponStats.globalArea.Value)
				child.localScale *= _weaponStats.area * _weaponStats.globalArea.Value;
				_lastArea = _weaponStats.area + _weaponStats.globalArea.Value;

				child.gameObject.SetActive(true);
				Collider2D col = child.GetComponent<Collider2D>();

				// Deal damage to enemies
				yield return new WaitForSeconds(_weaponStats.projectInverval);
				child.gameObject.SetActive(false);
			}
			yield return new WaitForSeconds(cooldown/_weaponStats.globalCooldown.Value);
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
				baseDamage += 5;
				break;

			case 4:
				baseDamage += 5;
				area += .1f;
				break;

			case 5:
				baseDamage += 5;
				break;

			case 6:
				baseDamage += 5;
				area += .1f;
				break;

			case 7:
				baseDamage += 5;
				break;

			case 8:
				baseDamage += 5;
				_reachedMaxLevel = true;
				if (Utilities.Instance._ownedObjects.Contains(this.gameObject))
				{
					Utilities.Instance._ownedObjects.Remove(this.gameObject);
				}
				LevelUpBehavior levelUpSystem = FindObjectOfType<LevelUpBehavior>();
				if (levelUpSystem._rewards.Contains(this.gameObject))
				{
					levelUpSystem._rewards.Remove(this.gameObject);
				}
				break;
		}
	}
}
