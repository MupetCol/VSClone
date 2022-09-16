using UnityEngine;

public class ChangeStage : MonoBehaviour
{
	public FloatReference _stage;

	public void ChangeStageOnSelected(float index)
	{
		_stage.Value = index;
	}
}
