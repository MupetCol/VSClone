using UnityEngine;

public class Vacuum : CollectableBase, ICollectable
{

	public void Collected()
	{
		foreach(ExpGem gem in Utilities.Instance._expGems){
			gem.GetComponent<CollectableBase>().CollectionEnabled(Utilities.Instance._player);
		}
		Destroy(gameObject);
	}
}
