using UnityEngine;

[CreateAssetMenu]
public class FloatReference : ScriptableObject
{
	public float Value;
	public float defaultValue;

	private void OnDisable()
	{
		Value = defaultValue;
	}
}
