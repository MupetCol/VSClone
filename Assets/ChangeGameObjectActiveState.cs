using UnityEngine;

public class ChangeGameObjectActiveState : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	public GameObject _gameObject;

	#endregion

	#region PRIVATE_VARIABLES

	bool _state;

	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

	public void ChangeState()
	{
		_state = _gameObject.activeSelf;
		_gameObject.SetActive(!_state);
	}

	#endregion
}
