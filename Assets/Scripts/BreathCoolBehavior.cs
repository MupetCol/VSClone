using UnityEngine;
using System.Collections;

public class BreathCoolBehavior : WeaponBase, ILevelUp<float>
{
	#region PUBLIC_VARIABLES

	public GameObject _projectile;
	public Transform _spawnPoint;
	private float _timer;

	#endregion

	#region PRIVATE_VARIABLES

	#endregion

	#region UNITY_METHODS

	void Start()
	{
		StartCoroutine(BreathCoolFlow());
	}

	#endregion

	IEnumerator BreathCoolFlow()
	{
		while (true)
		{
			_timer = 0;

			while(_timer < duration)
			{
				_timer += _weaponStats.projectInverval;

				var project = Instantiate(_projectile, _spawnPoint.position, Quaternion.identity);
				project.GetComponent<WeaponDealDamage>()._weapon = this;
				yield return new WaitForSeconds(_weaponStats.projectInverval);
			}
			yield return new WaitForSeconds((cooldown+duration) / _weaponStats.globalCooldown.Value);
		}
	}

	public void LevelUp(float level)
	{
		_currentLevel++;
		if (_reachedMaxLevel)
		{
			Debug.Log("Shouldn't have been called, already max level");
		}

		// TO BE CHANGED LATER
		switch (level)
		{
			case 2:
				duration++;
				break;

			case 3:
				cooldown -= .2f; //should rest .2seconds, not percent based
				break;

			case 4:
				duration++;
				break;

			case 5:
				baseDamage += 10;
				break;

			case 6:
				cooldown -= .2f;
				break;

			case 7:
				duration++;
				break;

			case 8:
				baseDamage += 10;
				_reachedMaxLevel = true;
				if (Utilities.Instance._ownedObjects.Contains(this.gameObject))
				{
					Utilities.Instance._ownedObjects.Remove(this.gameObject);
				}
				break;
		}
	}

}
