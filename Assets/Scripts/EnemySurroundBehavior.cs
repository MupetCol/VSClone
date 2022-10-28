using UnityEngine;
using System.Collections.Generic;

public class EnemySurroundBehavior : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	[SerializeField] private GameObject _enemy;
	[SerializeField] private int _spawnedEnemiesNumber;

	private GameObject _player;
	private List<EnemyMovement> _enemiesSpawned = new List<EnemyMovement>();

	#endregion

	#region PRIVATE_VARIABLES



	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

	void Start()
    {
		GameObject player = FindObjectOfType<PlayerMovement>().gameObject;
		for (int i = 0; i < _spawnedEnemiesNumber; i++)
		{
			float angle = (360.0f / _spawnedEnemiesNumber) * i;
			Vector3 position = Quaternion.Euler(0, 0, angle) * Vector3.up * 5;
			var temp = Instantiate(_enemy, player.transform.position + position, Quaternion.identity);
		}
		
	}

    void Update()
    {
        
    }

	#endregion
}
