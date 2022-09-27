using UnityEngine;
using System.Collections;

public class Orologion : CollectableBase, ICollectable
{
	public float _freezeTime;
	public void Collected()
	{
		foreach(EnemyBehavior enem in Utilities.Instance._enemies){
			enem.Freeze(_freezeTime);
		}
		Destroy(gameObject);
	}
}
