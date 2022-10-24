using UnityEngine;

[CreateAssetMenu]
public class BoolReference : ScriptableObject
{
	public bool toggle;

	private void OnEnable()
	{
		hideFlags = HideFlags.DontUnloadUnusedAsset;
	}

	public void Toggle()
	{
		toggle = !toggle;
	}
}
