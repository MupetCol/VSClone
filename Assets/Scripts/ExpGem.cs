using UnityEngine;

public class ExpGem : CollectableBase, ICollectable
{
	public float _value;
	public FloatReference _expCounter;
	public FloatReference _growth;

	private void Awake() {
		Utilities.Instance._expGems.Add(this);
	}

	public void Collected()
	{
		_expCounter.Value += (_value*_growth.Value);
		Destroy(gameObject);
	}

	private void OnDestroy() {
		Utilities.Instance._expGems.Remove(this);
	}
}
