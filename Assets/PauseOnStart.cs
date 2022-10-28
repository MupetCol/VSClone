using UnityEngine;

public class PauseOnStart : MonoBehaviour
{

	#region UNITY_METHODS

    void Start()
    {
        PauseControl.Instance.TogglePause();
	}

	#endregion
}
