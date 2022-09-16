using UnityEngine;

public class ExpGem : CollectableBase, ICollectable
{
	public float _value;
	public FloatReference _expCounter;

	public void Collected()
	{
		_expCounter.Value += _value;
		Destroy(gameObject);
	}
}
