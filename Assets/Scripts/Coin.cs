using UnityEngine;

public class Coin : CollectableBase, ICollectable
{
	public float _value;
	public FloatReference _coinsCounter;
	public FloatReference _coinsCollectedAchievement;

	public void Collected()
	{
		_coinsCounter.Value += _value;
		_coinsCollectedAchievement.Value += _value;
		Destroy(gameObject);
	}
}
