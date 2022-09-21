using UnityEngine;

public class CollisionWithMapsHandler : MonoBehaviour
{
	#region PUBLIC_VARIABLES


	#endregion

	#region PRIVATE_VARIABLES

	MapGeneratorNew _mapGenerator;

	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

    private void Awake() 
	{
		_mapGenerator = FindObjectOfType<MapGeneratorNew>();
	}

    private void OnTriggerEnter2D(Collider2D other) 
	{
		if(other.tag == "Map")
		{
			_mapGenerator.GenerateMap(other.transform);
		}
	}

	#endregion
}
