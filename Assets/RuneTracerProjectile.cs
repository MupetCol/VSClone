using UnityEngine;

public class RuneTracerProjectile : MonoBehaviour
{
	#region PUBLIC_VARIABLES
	public Weapon _runeTracerStats;
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
	}

	public void SetDirection(Transform target, float offset)
	{
		//if (target != null)
		//{
		//	_direction = target.position + new Vector3(0, offset, 0) - transform.position;
		//	_direction.Normalize();
		//}
	}

	void Update()
	{
		if(Vector3.Distance(_origin, transform.position) > _distanceToBounce)
		{
			_hasBounced = true;
		}
		if(_hasBounced)
		{
			transform.Translate(_direction * _runeTracerStats.speed * Time.deltaTime);
		}
		else
		{
			transform.Translate(-_direction * _runeTracerStats.speed * Time.deltaTime);
		}

	}

	#endregion
}
