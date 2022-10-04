using UnityEngine;

public class ChangeGameObjectActiveState : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	#endregion

	#region PRIVATE_VARIABLES

	bool _state;

	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

	public void ChangeState(GameObject obj)
	{
		_state = obj.activeSelf;
		obj.SetActive(!_state);
	}

	#endregion
}
