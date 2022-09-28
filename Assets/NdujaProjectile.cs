using UnityEngine;

public class NdujaProjectile : Projectile
{
	#region PUBLIC_VARIABLES

	#endregion

	#region PRIVATE_VARIABLES

	private float _speed;
	private Vector3 _direction = Vector3.right;

	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

	private void Awake()
	{
		transform.localScale *= _weapon.area * _weapon.globalArea.Value;
	}

	public void SetDirection(Vector3 direction, float speed, float offset, bool axis)
	{
		if (!axis)
		{
			_direction = direction + new Vector3(0, offset, 0);
		}
		else
		{
			_direction = direction + new Vector3(offset, 0, 0);
		}
	
		_direction.Normalize();
		_speed = speed;
	}

	void Update()
	{
		transform.Translate(_direction * Time.deltaTime * _speed);
	}
	#endregion
}
