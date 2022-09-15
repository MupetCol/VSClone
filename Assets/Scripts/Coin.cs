using UnityEngine;

public class Coin : CollectableBase, ICollectable
{
	public float _value;
	public FloatReference _coinsCounter;

	public void Collected()
	{
		_coinsCounter.Value += _value;
		Debug.Log("I've been collected");
		Destroy(gameObject);
	}
}
