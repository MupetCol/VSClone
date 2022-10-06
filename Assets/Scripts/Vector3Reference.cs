using UnityEngine;

[CreateAssetMenu]
public class Vector3Reference : ScriptableObject
{
	public Vector3 Value;
	public Vector3 defaultValue;
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