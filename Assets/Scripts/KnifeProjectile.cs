using UnityEngine;

public class KnifeProjectile : Projectile
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

	public void SetDirection(Vector3 direction, float speed)
	{
		_direction = direction;
		_speed = speed;
	}

	void Update()
	{
		transform.Translate(_direction * Time.deltaTime *_speed);
	}
	#endregion
}