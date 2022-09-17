using UnityEngine;
using System.Collections;

public class WeaponDealDamage : DealDamageOnCollision
{
	#region PUBLIC_VARIABLES

	public bool _triggerDamage;
	public bool _tickDamage;

	#endregion

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

}
