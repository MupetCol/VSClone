using UnityEngine;

public class ToggleFullScreen : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	public BoolReference _toggle;
	#endregion

	public void ToggleFS()
	{
		Screen.fullScreen = _toggle.toggle;
	}

	#region PRIVATE_VARIABLES


	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

    void Start()
    {
        
    }

    void Update()
    {
        
    }

	#endregion
}
