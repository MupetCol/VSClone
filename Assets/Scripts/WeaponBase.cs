using UnityEngine;

public class WeaponBase : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	public Weapon _weaponStats;

	#endregion

	#region PRIVATE_VARIABLES

	protected int weaponLevel;
	protected int maxLevel;
	protected int baseDamage;
	protected int amount;
	protected int pierce;
	protected int poolLimit;
	protected int rarity;

	protected float speed;
	protected float area;
	protected float duration;
	protected float cooldown;
	protected float projectInverval;
	protected float hitboxDelay;
	protected float knockBack;

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
