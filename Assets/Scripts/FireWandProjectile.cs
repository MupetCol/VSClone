using UnityEngine;

public class FireWandProjectile : MonoBehaviour
{
	#region PUBLIC_VARIABLES
	public Weapon _fireWandStats;

	#endregion

	#region PRIVATE_VARIABLES

	public Vector3 _direction;

	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

	private void Awake()
	{
		_direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
	}

	public void SetDirection(Transform target, float offset)
	{
		if (target != null)
		{
			_direction = target.position + new Vector3(0,offset,0) - transform.position;
			_direction.Normalize();
		}
	}

	void Update()
	{
		transform.Translate(_direction * _fireWandStats.speed * Time.deltaTime);
	}

	#endregion
}
