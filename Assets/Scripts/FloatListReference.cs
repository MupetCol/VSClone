using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu]
public class FloatListReference : ScriptableObject
{
	public List<float> values = new List<float>();
	public bool reset;

	private void OnEnable()
	{
		if (reset)
			values.Clear();
	}

	public void ResetValues()
	{
		if (reset)
			values.Clear();
	}
}