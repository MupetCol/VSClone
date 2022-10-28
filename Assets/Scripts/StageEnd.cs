using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StageEnd : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	public SaveFile _saveFile;
	public FloatReference _coinsOnStage, _coinsOwned;

	#endregion

	#region PRIVATE_VARIABLES


	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

	private void OnDestroy()
	{
		
	}

	public void StartEndingCor()
	{
		StartCoroutine(StageEndFlow());
	}

	IEnumerator StageEndFlow()
	{
		_coinsOwned.Value += _coinsOnStage.Value;
		_coinsOnStage.Value = 0;
		_saveFile.ResetFile();
		SceneManager.LoadScene(0);
		yield return null;
	}

	#endregion
}
