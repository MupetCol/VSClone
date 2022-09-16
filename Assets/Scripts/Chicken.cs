using UnityEngine;

public class Chicken : CollectableBase, ICollectable
{
	public float _value;
	public FloatReference _playerHealth;

	public void Collected()
	{
		
		_playerHealth.Value = Mathf.Clamp(_playerHealth.Value + _value, 0, Utilities.Instance._maxHealth);
		Destroy(gameObject);
	}
}
