using UnityEngine;

public class KnifeProjectile : Projectile
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

	public void SetDirection(Vector3 direction)
	{
		_direction = direction;
	}

	void Update()
	{
		transform.Translate(_direction * Time.deltaTime *_speed);
	}
	#endregion
}