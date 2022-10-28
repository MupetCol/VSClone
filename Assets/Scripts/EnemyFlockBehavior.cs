using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemyFlockBehavior : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	[SerializeField] private GameObject _enemy;
	[SerializeField] private int _spawnedEnemiesNumber;

	private GameObject _player;
	private List<EnemyMovement> _enemiesSpawned = new List<EnemyMovement>();

	private bool _one, _two, _three, _four, _five, _six, _seven, _eight;

	#endregion

	#region PRIVATE_VARIABLES


	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

	private void Awake()
	{
		_player = FindObjectOfType<PlayerMovement>().gameObject;
	}

	void Start()
    {
		for (int i = 0; i < _spawnedEnemiesNumber; i++)
		{
			if(!_one)
			{
				var temp = Instantiate(_enemy, transform.position +  new Vector3(.1f, .1f), Quaternion.identity);
				_enemiesSpawned.Add(temp.GetComponent<EnemyMovement>());
				_one = true;
			}else if(!_two)
			{
				_two = true;
				var temp = Instantiate(_enemy, transform.position + new Vector3(-.1f, -.1f), Quaternion.identity);
				_enemiesSpawned.Add(temp.GetComponent<EnemyMovement>());
			}
			else if (!_three)
			{
				_three = true;
				var temp = Instantiate(_enemy, transform.position + new Vector3(-.1f, .1f), Quaternion.identity);
				_enemiesSpawned.Add(temp.GetComponent<EnemyMovement>());
			}
			else if (!_four)
			{
				_four = true;
				var temp = Instantiate(_enemy, transform.position + new Vector3(.1f, -.1f), Quaternion.identity);
				_enemiesSpawned.Add(temp.GetComponent<EnemyMovement>());
			}
			else if (!_five)
			{
				_five = true;
				var temp = Instantiate(_enemy, transform.position + new Vector3(0, -.1f), Quaternion.identity);
				_enemiesSpawned.Add(temp.GetComponent<EnemyMovement>());
			}
			else if (!_six)
			{
				_six = true;
				var temp = Instantiate(_enemy, transform.position + new Vector3(0, .1f), Quaternion.identity);
				_enemiesSpawned.Add(temp.GetComponent<EnemyMovement>());
			}
			else if (!_seven)
			{
				_seven = true;
				var temp = Instantiate(_enemy, transform.position + new Vector3(.1f, 0), Quaternion.identity);
				_enemiesSpawned.Add(temp.GetComponent<EnemyMovement>());
			}
			else if (!_eight)
			{
				_eight = true;
				var temp = Instantiate(_enemy, transform.position + new Vector3(-.1f, 0), Quaternion.identity);
				_enemiesSpawned.Add(temp.GetComponent<EnemyMovement>());
			}
			else
			{
				var temp = Instantiate(_enemy, transform.position + Vector3.zero, Quaternion.identity);
				_enemiesSpawned.Add(temp.GetComponent<EnemyMovement>());
				_one = false;
				_two = false;
				_three = false;
				_five = false;
				_six = false;
				_seven = false;
				_eight = false;
				_four = false;
			}
		}

		foreach (EnemyMovement enemy in _enemiesSpawned)
		{
			enemy._fixedPosition = (_player.transform.position - transform.position).normalized;
		}

		_enemiesSpawned.Clear();
	}

    #endregion
}
