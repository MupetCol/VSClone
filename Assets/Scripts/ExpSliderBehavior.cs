using UnityEngine;
using UnityEngine.UI;

public class ExpSliderBehavior : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	public FloatReference _exp;

	#endregion

	#region PRIVATE_VARIABLES

	private Slider _expBar;

	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

	void Start()
	{
		_expBar = GetComponent<Slider>();
	}

	void Update()
	{
		if(_exp.Value != 0)
		_expBar.value = _exp.Value / Utilities.Instance._expToLevelUp;
	}

	#endregion
}

