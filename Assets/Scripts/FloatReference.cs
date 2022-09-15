using UnityEngine;

[CreateAssetMenu]
public class FloatReference : ScriptableObject
{
	public float Value;
	public float defaultValue;
	public bool reset;

	private void OnDisable()
	{
		if(reset)
		Value = defaultValue;
	}
}
