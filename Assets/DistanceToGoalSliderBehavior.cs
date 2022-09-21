using UnityEngine;
using UnityEngine.UI;

public class DistanceToGoalSliderBehavior : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	public FloatReference _distance;

	#endregion

	#region PRIVATE_VARIABLES

	private Slider _distanceBar;

	#endregion


	#region UNITY_METHODS

	void Start()
	{
		_distanceBar = GetComponent<Slider>();
	}

	void Update()
	{
		if(_distance.Value != 0)
		_distanceBar.value = _distance.Value / Utilities.Instance._initDistanceToGoal;
	}

	#endregion
}
