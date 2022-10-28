using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	public bool _projectileCustomDestroyTime;
	public float _destroyTime;
	public float _projectileSpeed;

	private Vector3 _dir;
	

	#endregion

	#region PRIVATE_VARIABLES


	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

	void Start()
	{
		if (_projectileCustomDestroyTime)
		{
			Destroy(gameObject, _destroyTime);
		}
		_dir = (FindObjectOfType<PlayerMovement>().transform.position - transform.position).normalized;
	}

	public void SetDirection()
	{
		_dir = (FindObjectOfType<PlayerMovement>().transform.position - transform.position).normalized;
	}

	void Update()
	{
		transform.Translate(_dir * Time.deltaTime * _projectileSpeed);
	}

	#endregion
}
