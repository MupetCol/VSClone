using UnityEngine;

public class StageAudioOnTime : MonoBehaviour
{
	#region PUBLIC_VARIABLES
	public FloatReference _time;
	private bool _midStage = false, _finalStage = false;
	public string _startStageAudioName, _midStageAudioName, _endStageAudioName;

	#endregion

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
        if(_time.Value < 1680 && _midStage == false)
		{
			_midStage = true;
			AudioManager.instance.StartSwap(_startStageAudioName, _midStageAudioName);
		}

		if (_time.Value < 120 && _finalStage == false)
		{
			_finalStage = true;
			AudioManager.instance.StartSwap(_midStageAudioName, _endStageAudioName);
		}
	}

	#endregion
}
