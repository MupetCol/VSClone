using UnityEngine;

public class LittleHeart : CollectableBase, ICollectable
{
	public FloatReference _playerHealth;

	public void Collected()
	{
		
		_playerHealth.Value += 1;
		Destroy(gameObject);
	}
}
