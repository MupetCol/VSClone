using UnityEngine;

public class SwapAudioFade : MonoBehaviour
{
	#region PUBLIC_VARIABLES
	public string _audioToReplaceName;
	public string _newAudioName;

	#endregion

	#region PRIVATE_VARIABLES


	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

    public void CallAudioSwap()
	{
		AudioManager.instance.StartSwap(_audioToReplaceName, _newAudioName);
	}

	#endregion
}
