using UnityEngine;
using System.Collections;

public class EnemyTimeEvents : MonoBehaviour
{
	#region PUBLIC_VARIABLES


	#endregion

	#region PRIVATE_VARIABLES

	[SerializeField] private FloatReference _timer;
	[SerializeField] private float[] _timeStampsInSeconds;
	[SerializeField] private bool[] _hasEventHappened;
	[SerializeField] private GameObject[] _events;

	//For events that need and random spawn points, like bosses
	[SerializeField] private Transform[] _spawnPoints;
	[SerializeField] private bool[] _eventNeedsRandomSpawnPoint;

	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

	private void Start()
	{
		for (int i = 0; i < _timeStampsInSeconds.Length; i++)
		{
			if(_timeStampsInSeconds[i] < (1800 % _timer.Value))
			{
				_hasEventHappened[i] = true;
			}
		}
		StartCoroutine(CheckForTimeStamps());
	}

	public IEnumerator CheckForTimeStamps()
	{
		while (true)
		{
			for (int i = 0; i < _timeStampsInSeconds.Length; i++)
			{
				if(_timeStampsInSeconds[i] < (1800 % _timer.Value  ) && !_hasEventHappened[i])
				{
					if (_eventNeedsRandomSpawnPoint[i])
					{
						if(_events[i])
							Instantiate(_events[i], _spawnPoints[Random.Range(0, _spawnPoints.Length)].position, Quaternion.identity);
						_hasEventHappened[i] = true;
					}
					else
					{
						if (_events[i])
							Instantiate(_events[i]);
						_hasEventHappened[i] = true;
					}
				}
			}
			yield return new WaitForSeconds(1f);
		}
	}

	#endregion
}
