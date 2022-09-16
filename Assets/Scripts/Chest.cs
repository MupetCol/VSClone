using UnityEngine;

public class Chest : CollectableBase, ICollectable
{
	public float _value;
	public GameObject _chestUI;

	public void Collected()
	{
		//Enable chest UI, that  game object should
		//pause the game and execute a coroutine on enable
		//_chestUI.SetActive(true);
		Debug.Log("I've been collected");
		Destroy(gameObject);
	}
}
