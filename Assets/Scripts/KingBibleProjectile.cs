using UnityEngine;

public class KingBibleProjectile : MonoBehaviour
{
	#region PUBLIC_VARIABLES
	public Weapon _kingBibleStats;

	#endregion

	#region PRIVATE_VARIABLES

	private float _speed;
	private bool _rotate;
	private GameObject _pivot;

	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

	public void SetValues(float speed, GameObject pivot, bool rotate, float distance)
	{
		_speed = speed;
		_pivot = pivot;
		_rotate = true;
		//SetPosition(distance);
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
