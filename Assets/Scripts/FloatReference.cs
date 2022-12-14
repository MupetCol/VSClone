using UnityEngine;

[CreateAssetMenu]
public class FloatReference : ScriptableObject
{
	public float Value;
	public float defaultValue;
	public bool reset;

	private void OnEnable()
	{
		hideFlags = HideFlags.DontUnloadUnusedAsset;
		if (reset)
			Value = defaultValue;
	}

	public void ResetValues()
	{
		if (reset)
			Value = defaultValue;
	}
}
