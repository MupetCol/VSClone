using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DealDamageOnCollision : MonoBehaviour
{
	#region PUBLIC_VARIABLES


	#endregion

	#region PRIVATE_VARIABLES

	protected float _damage = 0f;
	protected float _hitboxDelay = .1f;
	protected float _knockBack = 1f;
	public bool _constant;
	protected Collider2D _collider;
	private LayerMask _enemyLayer;

	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

	public virtual void Awake()
	{
		_collider = GetComponent<Collider2D>();
		_enemyLayer = LayerMask.GetMask("Enemies");
	}

	protected virtual void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.TryGetComponent(out IDamageable<float,float> dam))
		{
			dam.Damage(_damage,_knockBack);
		}
	}

	protected IEnumerator DamageOnEnemiesOnArea()
	{
		ContactFilter2D filter = new ContactFilter2D();
		filter.SetLayerMask(_enemyLayer);
		List<Collider2D> colliders = new List<Collider2D>();
		while(_constant)
		{
			Physics2D.OverlapCollider(_collider, filter, colliders);

			Debug.Log(colliders.Count);

			foreach (Collider2D col in colliders)
			{
				col.GetComponent<IDamageable<float,float>>().Damage(_damage,_knockBack);
			}

			colliders.Clear();
			yield return new WaitForSeconds(_hitboxDelay);
		} 
	}


	#endregion
}
