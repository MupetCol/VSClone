using UnityEngine;

public class Rosary : CollectableBase, ICollectable
{
	public RosaryFunctionHolder _rosaryObject;

	private void Awake() {
		_rosaryObject = FindObjectOfType<RosaryFunctionHolder>();
	}

	public void Collected()
	{
		_rosaryObject.KillEnemiesOnScreen();
		Destroy(gameObject);
	}
}
