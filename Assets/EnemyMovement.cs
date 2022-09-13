using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	#region PUBLIC_VARIABLES


	#endregion

	#region PRIVATE_VARIABLES

	private GameObject _player;
	public Enemy _enemyStats;

	private float _trackingSpeed;


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
		transform.Translate((_player.transform.position - transform.position).normalized * Time.deltaTime * _trackingSpeed);
	}

	#endregion
}
