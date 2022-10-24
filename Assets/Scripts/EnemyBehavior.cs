using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour, IDamageable<float,float>, IKillable
{
	#region PUBLIC_VARIABLES

	public Enemy _enemyStats;
	public float _health;
	public int _enemyType = 0;
	public GameObject _numberPrefab;
	public BoolReference _floatingNumbers;
	public BoolReference _knockBackFlash;

	#endregion

	#region PRIVATE_VARIABLES

	private GameObject _player;

	private float _timeBetweenHit = 0.1f;
	private float _damagePoints;

	private Rigidbody2D _rigidbody;

	private bool _canDealDamage = true;
	public bool _frozen = false;
	private DropCollectable _dropper;
	private EnemyMovement _movement;

	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES

	[SerializeField] private GameObject _whiteCopy;

	#endregion

	#region UNITY_METHODS

	private void Awake()
	{
		Utilities.Instance._enemies.Add(this);
		_movement = GetComponent<EnemyMovement>();
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
		if (collision.gameObject.tag == "Player" && _canDealDamage && !_frozen)
		{
			StartCoroutine(DealDamage(collision));
		}
	}

	private void OnDestroy() {
		Utilities.Instance._enemies.Remove(this);
	}



	#endregion

	public void Freeze(float freezeTime){
		StartCoroutine(FreezeCor(freezeTime));
	}

	public IEnumerator FreezeCor (float freezeTime)
	{
		Color DefColor = GetComponent<SpriteRenderer>().color;
		GetComponent<SpriteRenderer>().color = Color.blue;
		_frozen = true;
		_movement._frozen = true;
		yield return new WaitForSeconds(freezeTime);
		_frozen = false;
		_movement._frozen = false;
		GetComponent<SpriteRenderer>().color = DefColor;
	}

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

		if (_floatingNumbers.toggle)
		{
			var obj = Instantiate(_numberPrefab, transform.position, Quaternion.identity);
			obj.GetComponentInChildren<DamageNumberBehavior>().UpdateText(damageTaken.ToString());
		}

		if (_health <= 0) Kill();
	}

	public void Kill()
	{
		_dropper.Drop();
		Destroy(this.gameObject);
	}

	private void KnockBack(float weaponKnockBackStat)
	{
		if(_knockBackFlash.toggle)
		StartCoroutine(KnockbackFlash());

		transform.Translate(-(_player.transform.position - transform.position).normalized * _enemyStats.knockback * weaponKnockBackStat);
	}
}
