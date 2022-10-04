using UnityEngine;
using System.Collections;

public class WeaponBase : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	public Weapon _weaponStats;
	public bool _reachedMaxLevel;
	public int _currentLevel = 1;

	#endregion

	#region PRIVATE_VARIABLES

	// In-game stats
	public float baseDamage = 0f;
	public float amount = 0f;
	public float pierce = 0f;
	public float poolLimit = 0f;
	public float rarity = 0f;
	public float speed = 0f;
	public float area = 0f;
	public float duration = 0f;
	public float cooldown = 0f;
	public float projectInverval = 0f;
	public float hitboxDelay = 0f;
	public float knockBack = 0f;

	#endregion
	
	public virtual void Awake()
	{
		StartCoroutine(InitLevelUp());
		baseDamage += _weaponStats.baseDamage;
		rarity += _weaponStats.rarity;
		cooldown += _weaponStats.cooldown;
		amount += _weaponStats.amount;
		pierce += _weaponStats.pierce;
		poolLimit += _weaponStats.poolLimit;
		speed += _weaponStats.speed;
		area += _weaponStats.area;
		duration += _weaponStats.duration;
		projectInverval += _weaponStats.projectInverval;
		hitboxDelay += _weaponStats.hitboxDelay;
		knockBack += _weaponStats.knockBack;
	}

	public virtual void LevelUp(int level)
	{
		_currentLevel++;
	}

	IEnumerator InitLevelUp()
	{
		int minLevel = 1;
		while (minLevel < _currentLevel)
		{
			minLevel++;
			LevelUp(minLevel);
			Debug.Log(minLevel);
			yield return new WaitForSeconds(.05f);
			_currentLevel--;
		}

	}
}
