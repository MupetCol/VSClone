using UnityEngine;

public class FireWandProjectile : Projectile
{

	#region PRIVATE_VARIABLES

	public Vector3 _direction;
	public float _speed;

	#endregion

	#region UNITY_METHODS

	private void Awake()
	{
		_direction = Vector3.right;
		transform.localScale *= _weapon.area * _weapon.globalArea.Value;
	}

	public void SetDirection(Vector3 target, float offset)
	{
		if (target != null)
		{
			_direction = target + new Vector3(0,offset,0) - transform.position;
			_direction.Normalize();
		}
	}

	void Update()
	{
		transform.Translate(_direction * _speed * Time.deltaTime);
	}

	#endregion
}
