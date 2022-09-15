using UnityEngine;

public class CollectionEnabler : MonoBehaviour
{
	#region PUBLIC_VARIABLES


	#endregion

	#region PRIVATE_VARIABLES


	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Collectable")
		{
			collision.GetComponent<CollectableBase>().CollectionEnabled(transform);
		}
	}

	#endregion
}
