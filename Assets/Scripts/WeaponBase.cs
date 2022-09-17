using UnityEngine;

public class WeaponBase : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	public Weapon _weaponStats;

	#endregion

	#region PRIVATE_VARIABLES

	public float weaponLevel;
	public float maxLevel;
	public float baseDamage;
	public float amount;
	public float pierce;
	public float poolLimit;
	public float rarity;
	public float speed;
	public float area;
	public float duration;
	public float cooldown;
	public float projectInverval;
	public float hitboxDelay;
	public float knockBack;

	#endregion
	
	public virtual void Awake()
	{
		weaponLevel = _weaponStats.weaponLevel;
		maxLevel = _weaponStats.maxLevel;
		baseDamage = _weaponStats.baseDamage;
		rarity = _weaponStats.rarity;
		cooldown = _weaponStats.cooldown;
		amount = _weaponStats.amount;
		pierce = _weaponStats.pierce;
		poolLimit = _weaponStats.poolLimit;
		speed = _weaponStats.speed;
		area = _weaponStats.area;
		duration = _weaponStats.duration;
		projectInverval = _weaponStats.projectInverval;
		hitboxDelay = _weaponStats.hitboxDelay;
		knockBack = _weaponStats.knockBack;
	}
}
