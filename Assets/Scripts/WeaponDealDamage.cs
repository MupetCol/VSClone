using UnityEngine;
using System.Collections;

public class WeaponDealDamage : DealDamageOnCollision
{
	#region PUBLIC_VARIABLES

	public Weapon _weapon;
	public bool _triggerDamage;
	public bool _tickDamage;

	#endregion

	#region PRIVATE_VARIABLES


	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

	public override void Awake()
	{
		base.Awake();
		_damage = _weapon.baseDamage;
		_hitboxDelay = _weapon.hitboxDelay;
		_knockBack = _weapon.knockBack;
	}

	protected override void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Enemy" && _triggerDamage)
		{
			base.OnTriggerEnter2D(collision);
		}
	}

	private void OnEnable()
	{
		if(_tickDamage)
		StartCoroutine(DamageOnEnemiesOnArea());
	}

	private void OnDisable()
	{
		StopCoroutine(DamageOnEnemiesOnArea());
	}

	#endregion
}
