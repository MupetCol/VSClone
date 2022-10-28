using UnityEngine;

public class ChangeBoolReference : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	public BoolReference _toggle;

	#endregion

	public void ChangeBool(bool status)
	{
		_toggle.toggle = status;
	}
}
