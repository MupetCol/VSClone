using UnityEngine;

public class KingBibleProjectile : Projectile
{
	#region PUBLIC_VARIABLES

	#endregion

	#region PRIVATE_VARIABLES

	public float _speed = 1f;
	private bool _rotate;
	private GameObject _pivot;

	#endregion

	#region UNITY_METHODS
	private void Awake()
	{
		transform.localScale *= _weapon.area * _weapon.globalArea.Value;
	}
	public void SetValues( GameObject pivot, bool rotate)
	{
		_pivot = pivot;
		_rotate = true;
	}

	public void SetPosition(float distance)
	{
		transform.position = new Vector3(distance, 0, 0);
	}

	void Update()
	{
		if(_rotate)
		transform.RotateAround(_pivot.transform.position, Vector3.forward, _speed * Time.deltaTime);
	}

	#endregion
}
