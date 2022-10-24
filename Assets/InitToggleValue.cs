using UnityEngine;
using UnityEngine.UI;

public class InitToggleValue : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	public BoolReference _toggleValue;

	#endregion

	#region PRIVATE_VARIABLES


	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

    void Awake()
    {
		GetComponent<Toggle>().isOn = _toggleValue.toggle;
		_toggleValue.toggle = GetComponent<Toggle>().isOn;

	}

    void Update()
    {
        
    }

	#endregion
}
