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

	private void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Enemy" && _canDealDamage)
		{
			StartCoroutine(DealDamage(collision));
		}
	}

	#endregion

	public IEnumerator DealDamage(Collision2D coll)
	{
		_canDealDamage = false;
		//coll.gameObject.GetComponent<Enemy>().Damage();
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
}
