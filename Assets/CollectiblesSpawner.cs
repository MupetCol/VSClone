using UnityEngine;
using System.Collections;

public class CollectiblesSpawner : MonoBehaviour
{
	#region PUBLIC_VARIABLES


	#endregion

	#region PRIVATE_VARIABLES


	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES

	[SerializeField] Transform[] _spawnPoints;
	[SerializeField] GameObject[] _collectibles;
	[SerializeField] float _spawnRate;

	private float _rarityPoolTotal;

	#endregion

	#region UNITY_METHODS

	void Start()
	{
		foreach(GameObject _collectible in _collectibles)
		{
			_rarityPoolTotal += _collectible.GetComponent<CollectableBase>()._rarity;
		}
		StartCoroutine(SpawnEnemies());
	}

	void Update()
	{

	}

	IEnumerator SpawnEnemies()
	{
		while (true)
		{
			float chanceToSpawn = Random.Range(1, 4);
			if(chanceToSpawn == 1)
			{
				float chance = Random.Range(0f, 100f);
				float totalWeight = 0;

				foreach (GameObject _collectible in _collectibles)
				{
					float weight = _collectible.GetComponent<CollectableBase>()._rarity / _rarityPoolTotal;
					totalWeight += weight;

					if (totalWeight > (chance / 100))
					{
						Instantiate(_collectible
						, _spawnPoints[Random.Range(0, _spawnPoints.Length)].position,
						Quaternion.identity);
						break;
					}

				}
			}
			yield return new WaitForSeconds(_spawnRate);
		}

	}


	#endregion
}
