using UnityEngine;

public class EnemyProjectileDealDamage : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	public Enemy _enemyStats;

	#endregion

	#region UNITY_METHODS

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			collision.gameObject.GetComponent<IDamageable<float, float>>().Damage(_enemyStats.power, 0);
			Destroy(gameObject);
		}
	}

	#endregion
}
