using UnityEngine;

public class ProjectileDestroyer : MonoBehaviour
{
	#region PUBLIC_VARIABLES


	#endregion

	#region PRIVATE_VARIABLES


	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Projectile")
		{
			Destroy(collision.gameObject);
		}
	}
	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Projectile")
		{
			Destroy(collision.gameObject);
		}
	}

	#endregion
}
