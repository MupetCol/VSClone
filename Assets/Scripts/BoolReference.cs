using UnityEngine;

[CreateAssetMenu]
public class BoolReference : ScriptableObject
{
	public bool toggle;

	private void OnEnable()
	{
		toggle = false;
	}
}
