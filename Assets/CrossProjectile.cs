using UnityEngine;

public class CrossProjectile : Projectile
{
	#region PUBLIC_VARIABLES

	public Vector3 _direction;
	public Vector3 _spawnPoint;

	#endregion

	#region PRIVATE_VARIABLES

	private bool _flightBack = false;

	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES

	[SerializeField] private float _distanceToFlightBackMultiplier;

	#endregion

	#region UNITY_METHODS

	private void Awake()
	{
		_direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
		transform.localScale *= _weapon.area * _weapon.globalArea.Value;
	}
	public void SetDirection(Transform target, Vector3 spawnPoint)
	{
		if (target != null)
		{
			_direction = target.position - transform.position;
			_direction.Normalize();
			_spawnPoint = spawnPoint;
		}
	}

	void Update()
	{
		if (Vector2.Distance(_spawnPoint, transform.position) >
		    (transform.localScale.x * _distanceToFlightBackMultiplier))
			_flightBack = true;

		if(!_flightBack)
			transform.Translate(_direction * _weapon.speed * _weapon.globalSpeed.Value * Time.deltaTime);
		else
		{
			transform.Translate(-_direction * _weapon.speed * _weapon.globalSpeed.Value * Time.deltaTime);
		}
	}

	#endregion
}
