using UnityEngine;
using DG.Tweening;
using System.Collections;

public class PeachoneProjectile : Projectile
{
	#region PUBLIC_VARIABLES

	public Vector3 _target;
	public float _speed = 1f;

	#endregion

	#region PRIVATE_VARIABLES


	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

    void Start()
    {
		StartCoroutine(ProjectileLifetime());
    }

	public void SetTarget(Vector3 target)
	{
		_target = target;
	}

	IEnumerator ProjectileLifetime()
	{
		transform.DOMove(_target, _speed).SetEase(Ease.Linear);
		yield return new WaitForSeconds(_speed);
		GetComponent<Collider2D>().enabled = true;
		GetComponent<WeaponDealDamage>().enabled = true;
		GetComponent<SpriteRenderer>().enabled = false;
		yield return new WaitForSeconds(1f);
		Destroy(gameObject);
	}

	void Update()
    {
        
    }

	#endregion
}
