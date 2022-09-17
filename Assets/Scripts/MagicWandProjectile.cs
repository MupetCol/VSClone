using UnityEngine;

public class MagicWandProjectile : Projectile
{
	#region PUBLIC_VARIABLES

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

	public void SetDirection(Transform target)
    {
		if(target != null)
		{
			_direction = target.position - transform.position;
			_direction.Normalize();
		}
	}

    void Update()
    {
		transform.Translate(_direction * _weapon.speed * Time.deltaTime);
    }

	#endregion
}
