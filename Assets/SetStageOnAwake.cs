using UnityEngine;
using UnityEngine.UI;

public class SetStageOnAwake : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	public Toggle[] _toggles;
	public FloatReference _stage;

	#endregion

	#region PRIVATE_VARIABLES


	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

	private void Awake()
	{
		for (int i = 0; i < _toggles.Length; i++)
		{
			if (_toggles[i].isOn) _stage.Value = i+1;
		}
	}

	void Update()
    {
        
    }

	#endregion
}
