using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StageEnd : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	public SaveFile _saveFile;
	public FloatReference _coinsOnStage, _coinsOwned;
	public FloatReference _stageFinishAchievement;

	public GameObject _gameOverPopUp;

	#endregion

	#region UNITY_METHODS

	public void StartEndingCor()
	{
		StartCoroutine(StageEndFlow());
	}

	public void GameOverCor()
	{
		StartCoroutine(GameOver());
	}

	IEnumerator StageEndFlow()
	{
		_stageFinishAchievement.Value++;
		_coinsOwned.Value += _coinsOnStage.Value;
		_coinsOnStage.Value = 0;
		_saveFile.ResetFile();
		SceneManager.LoadScene(0);
		yield return null;
	}

	IEnumerator GameOver()
	{
		_coinsOwned.Value += _coinsOnStage.Value;
		_coinsOnStage.Value = 0;
		_saveFile.ResetFile();
		_gameOverPopUp.SetActive(true);
		yield return null;
	}

	#endregion
}
