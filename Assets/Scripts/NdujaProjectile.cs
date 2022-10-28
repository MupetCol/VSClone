using UnityEngine;

public class NdujaProjectile : Projectile
{
	#region PUBLIC_VARIABLES

	#endregion

	#region PRIVATE_VARIABLES

	public float _speed = 1f;
	private Vector3 _direction = Vector3.right;

	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

	private void Awake()
	{
		transform.localScale *= _weapon.area * _weapon.globalArea.Value;
	}

	public void SetDirection(Vector3 direction, float offset, bool axis)
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
	}

	void Update()
	{
		transform.Translate(_direction * Time.deltaTime * _speed);
	}
	#endregion
}
