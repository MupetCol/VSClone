using UnityEngine;
using System.Collections;

public class GarlicBehavior : WeaponBase
{
	#region PUBLIC_VARIABLES


	#endregion

	#region PRIVATE_VARIABLES

	private bool _canDealDamage = true;

	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

	void Start()
    {
        
    }

    void Update()
    {
        
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
}
