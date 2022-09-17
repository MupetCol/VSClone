using UnityEngine;
using System.Collections;

public class ToggleGameObject : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	public BoolReference _toggle;
	public GameObject _gameObject;

	private bool _toggleValue = false;

	#endregion

	#region PRIVATE_VARIABLES


	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	private void Update()
	{
		if (_toggleValue != _toggle.toggle)
		{
			_gameObject.SetActive(_toggle.toggle);
			_toggleValue = _toggle.toggle; ;
		}
	}

}
