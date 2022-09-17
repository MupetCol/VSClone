using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WhipBehavior : WeaponBase
{

	#region PRIVATE_SERIALIZED_VARIABLES


	#endregion

	#region UNITY_METHODS

    IEnumerator WhipFlow()
	{
		while (true)
		{
			for (int i = 0; i < amount; i++)
			{
				var child = transform.GetChild(i);
				child.gameObject.SetActive(true);
				Collider2D col = child.GetComponent<Collider2D>();
				GetEnemiesOnRange(col);
				// Deal damage to enemies
				yield return new WaitForSeconds(.1f);
				child.gameObject.SetActive(false);

			}
			yield return new WaitForSeconds(cooldown);
		}

	}
	void Start()
    {
        StartCoroutine(WhipFlow());
    }

	private void DealDamage(List<Collider2D> enemies)
	{
		foreach(Collider2D c in enemies)
		{
			//c.GetComponent<Enemy>
		}
	}
	

	private void GetEnemiesOnRange(Collider2D hitbox)
	{
		ContactFilter2D filter = new ContactFilter2D().NoFilter();
		List<Collider2D> results = new List<Collider2D>();
		hitbox.OverlapCollider(filter, results);
	}

	#endregion
}
