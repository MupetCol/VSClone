using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour, IDamageable<float,float>, IKillable
{
	#region PUBLIC_VARIABLES

	public Enemy _enemyStats;
	public float _health;

	#endregion

	#region PRIVATE_VARIABLES

	private GameObject _player;

	private float _timeBetweenHit = 0.1f;
	private float _damagePoints;

	private Rigidbody2D _rigidbody;

	private bool _canDealDamage = true;
	private DropCollectable _dropper;

	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES

	[SerializeField] private GameObject _whiteCopy;

	#endregion

	#region UNITY_METHODS

	private void Awake()
	{
		_player = FindObjectOfType<PlayerMovement>().gameObject;
		_damagePoints = _enemyStats.power;
		_health = _enemyStats.baseHealth;
		_rigidbody = GetComponent<Rigidbody2D>();
		_dropper = GetComponent<DropCollectable>();
		
	}
	void Start()
    {
		_player = FindObjectOfType<PlayerMovement>().gameObject;
    }

	private void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player" && _canDealDamage)
		{
			StartCoroutine(DealDamage(collision));
		}
	}



	#endregion

	public IEnumerator DealDamage(Collision2D coll)
	{
		_canDealDamage = false;
		coll.gameObject.GetComponent<IDamageable<float, float>>().Damage(_damagePoints, 0);
		yield return new WaitForSeconds(_timeBetweenHit);
		_canDealDamage = true;
	}

	IEnumerator KnockbackFlash()
	{
		_whiteCopy.SetActive(true);
		yield return new WaitForSeconds(.15f);
		_whiteCopy.SetActive(false);
	}

	public void Damage(float damageTaken, float weaponKnockBackStat)
	{
		_health -= damageTaken;
		KnockBack(weaponKnockBackStat);
		if (_health <= 0) Kill();
	}

	public void Kill()
	{
		_dropper.Drop();
		Destroy(this.gameObject);
	}

	private void KnockBack(float weaponKnockBackStat)
	{
		StartCoroutine(KnockbackFlash());
		transform.Translate(-(_player.transform.position - transform.position).normalized * _enemyStats.knockback * weaponKnockBackStat);
	}
}
