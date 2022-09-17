using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DealDamageOnCollision : MonoBehaviour
{
	#region PUBLIC_VARIABLES


	#endregion

	#region PRIVATE_VARIABLES

	public Weapon _weapon;
	public bool _constant;
	protected Collider2D _collider;
	private LayerMask _enemyLayer;
	private float _hitCount = 0;

	public List<GameObject> _targetsOnCooldown = new List<GameObject>();

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
		if(collision.TryGetComponent(out IDamageable<float,float> dam) && !_targetsOnCooldown.Contains(collision.gameObject))
		{
			// Deal damage and destroy projectile if pierce count is equal to hitcount
			// 0 on a weapon pierce stat is taken as "IGNORE" pierce stat
			_hitCount++;
			dam.Damage(_weapon.baseDamage * _weapon.globalMight.Value
					, _weapon.knockBack);
			if (_hitCount == _weapon.pierce && _weapon.pierce != 0) Destroy(this.gameObject);

			_targetsOnCooldown.Add(collision.gameObject);
			StartCoroutine(TargetCooldown(collision.gameObject));
		}
	}

	IEnumerator TargetCooldown(GameObject target)
	{
		yield return new WaitForSeconds(_weapon.hitboxDelay);
		_targetsOnCooldown.Remove(target);
	}

	protected IEnumerator DamageOnEnemiesOnArea()
	{
		ContactFilter2D filter = new ContactFilter2D();
		filter.SetLayerMask(_enemyLayer);
		List<Collider2D> colliders = new List<Collider2D>();

		do
		{
			Physics2D.OverlapCollider(_collider, filter, colliders);

			//Debug.Log(colliders.Count);

			foreach (Collider2D col in colliders)
			{
				col.GetComponent<IDamageable<float, float>>().Damage(_weapon.baseDamage * _weapon.globalMight.Value
					, _weapon.knockBack);
			}

			colliders.Clear();
			yield return new WaitForSeconds(_weapon.hitboxDelay);

		} while (_constant);
	}
	


	#endregion
}
