using UnityEngine;

public class AxeProjectile : Projectile
{
	#region PRIVATE_VARIABLES

	public Vector3 _direction;

	#endregion

	#region UNITY_METHODS

	private void Awake()
	{
		transform.localScale *= _weapon.area * _weapon.globalArea.Value;
	}

	public void SetDirection(float axeNumber, float force)
	{
		if(axeNumber % 3 == 1)
		{
			_direction = Vector3.up;
		}else if (axeNumber % 3 == 2)
		{
			_direction = new Vector3(.2f, 1, 0);
		}
		else 
		{
			_direction = new Vector3(-.2f, 1, 0);
		}
		_direction.Normalize();
		LaunchAxe(_direction,force);
	}

	private void LaunchAxe(Vector3 direction, float force)
	{
		GetComponent<Rigidbody2D>().AddForce(direction* force);
	}

	#endregion
}
