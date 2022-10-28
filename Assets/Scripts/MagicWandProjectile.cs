using UnityEngine;

public class MagicWandProjectile : Projectile
{

	#region PRIVATE_VARIABLES

	public Vector3 _direction;
	public float _speed = 1f;

	#endregion

	#region UNITY_METHODS

	private void Awake()
	{
		_direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
		transform.localScale *= _weapon.area * _weapon.globalArea.Value;
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
		transform.Translate(_direction * _speed * Time.deltaTime);
    }

	#endregion
}
