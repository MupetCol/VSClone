using UnityEngine;
using System.Collections;

public class CollectiblesSpawner : MonoBehaviour
{
	
	#region PRIVATE_SERIALIZED_VARIABLES

	[SerializeField] Transform[] _spawnPoints;
	[SerializeField] GameObject _bonfire;
	[SerializeField] float _spawnRate;

	#endregion

	#region UNITY_METHODS

	void Start()
	{
		StartCoroutine(SpawnCollectibles());
	}

	IEnumerator SpawnCollectibles()
	{
		while (true)
		{
			float chanceToSpawn = Random.Range(1, 4);
			if(chanceToSpawn == 1)
			{
				Instantiate(_bonfire
						, _spawnPoints[Random.Range(0, _spawnPoints.Length)].position,
						Quaternion.identity);
			}
			yield return new WaitForSeconds(_spawnRate);
		}

	}


	#endregion
}
