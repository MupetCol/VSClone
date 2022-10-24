using UnityEngine;

public class DistanceToGoalUpdate : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	[SerializeField] private FloatReference _distanceToGoal;
	[SerializeField] private GameObject[] _goals;
	
	/* Player moves 1 unit per second, meaning in 30 minutes a maximum of 1800 uinits
	 set according to that*/
	[SerializeField] private float _distanceOnStart;
	[SerializeField] private float _radiusOfNoDistanceProgress;

	private Vector2 _dir;

	#endregion

	#region PRIVATE_VARIABLES


	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

    void Awake()
    {
		foreach(GameObject go in _goals)
		{
			_dir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
			go.transform.position = _dir.normalized * _distanceOnStart;
		}
    }

    void FixedUpdate()
    {
		if(Vector2.Distance(transform.position, Vector2.zero) > _radiusOfNoDistanceProgress)
		{
			float minTemp = 10000f;
			GameObject go = _goals[0];
			foreach (GameObject g in _goals)
			{
				if(Vector2.Distance(transform.position, g.transform.position) < minTemp)
				{
					minTemp = Vector2.Distance(transform.position, g.transform.position);
					go = g;
				}
			}
			_distanceToGoal.Value = Utilities.Instance._initDistanceToGoal - Vector2.Distance(transform.position, go.transform.position);
			Debug.Log(_distanceToGoal.Value);
		}

    }

	#endregion
}
