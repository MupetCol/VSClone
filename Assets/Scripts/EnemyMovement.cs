using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
	#region PUBLIC_VARIABLES


	#endregion

	#region PRIVATE_VARIABLES

	private GameObject _player;
	public Enemy _enemyStats;
	public bool _fixedMovement;
	public float _trackingInterval = 0.1f;

	private float _trackingSpeed;
	private Vector3 _fixedPosition;
	private Vector3 _updatedPosition;


	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

	private void Awake()
	{
		_player = FindObjectOfType<PlayerMovement>().gameObject;
		_trackingSpeed = _enemyStats.speed;		
	}

	void Start()
    {
        if(!_fixedMovement)
			StartCoroutine(UpdateTargetPosition());

		_fixedPosition = (_player.transform.position - transform.position).normalized;
	}

    void Update()
    {
		// Create an offset so it doesnt follow the player directly, updates the direction every .2s might feel more
		// comfortable to the player

		// Create coroutine that updates the direction every some time, that way it wont folow the player like
		// a homing projectile
		Move();
		
	}

	void Move()
	{
		if (_player)
		{
			if (!_fixedMovement)
			{
				transform.Translate(_updatedPosition * Time.deltaTime * _trackingSpeed);
			}
			else
			{
				transform.Translate(_fixedPosition * Time.deltaTime * _trackingSpeed);
			}
		}
	}

	IEnumerator UpdateTargetPosition()
	{
		while (_player)
		{
			_updatedPosition = (_player.transform.position - transform.position).normalized;
			yield return new WaitForSeconds(_trackingInterval);
		}

	}

	#endregion
}
