using UnityEngine;

public class Clover : CollectableBase, ICollectable
{
	public float _value;
	public FloatReference _luck;

	public void Collected()
	{
		//Increase 10% luck
		_luck.Value += _value;
		Debug.Log("I've been collected");
		Destroy(gameObject);
	}
}
