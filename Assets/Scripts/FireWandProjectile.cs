using UnityEngine;

public class FireWandProjectile : Projectile
{

	#region PRIVATE_VARIABLES

	public Vector3 _direction;

	#endregion

	#region UNITY_METHODS

	private void Awake()
	{
		_direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
		transform.localScale *= _weapon.area * _weapon.globalArea.Value;
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
		transform.Translate(_direction * _weapon.speed * _weapon.globalSpeed.Value * Time.deltaTime);
	}

	#endregion
}
