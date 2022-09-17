using UnityEngine;

public class RuneTracerProjectile : Projectile
{
	#region PUBLIC_VARIABLES
	public float _distanceToBounce;
	public Vector3 _direction;


	#endregion

	#region PRIVATE_VARIABLES
	private Vector3 _origin;
	private bool _hasBounced = false;


	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

	private void Awake()
	{
		_direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
		_origin = transform.position;
		transform.localScale *= _weapon.area * _weapon.globalArea.Value;
	}

	void Update()
	{
		if(Vector3.Distance(_origin, transform.position) > _distanceToBounce)
		{
			_hasBounced = true;
		}
		if(_hasBounced)
		{
			transform.Translate(_direction * _weapon.speed * _weapon.globalSpeed.Value * Time.deltaTime);
		}
		else
		{
			transform.Translate(-_direction * _weapon.speed * _weapon.globalSpeed.Value * Time.deltaTime);
		}

	}

	#endregion
}
