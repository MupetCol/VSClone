using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
	#region PUBLIC_VARIABLES


	#endregion

	#region PRIVATE_VARIABLES


	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES

	[SerializeField] Transform[] _spawnPoints;
	[SerializeField] GameObject[] _enemies;
	[SerializeField] float _spawnRate;

	#endregion

	#region UNITY_METHODS

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    void Update()
    {
        
    }

	IEnumerator SpawnEnemies()
	{
		while (true)
		{
			Instantiate(_enemies[Random.Range(0, _enemies.Length)]
			,_spawnPoints[Random.Range(0, _spawnPoints.Length)].position, 
			Quaternion.identity);

			yield return new WaitForSeconds(_spawnRate);
		}

	}
	

	#endregion
}
