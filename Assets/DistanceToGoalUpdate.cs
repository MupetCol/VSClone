using UnityEngine;

public class DistanceToGoalUpdate : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	[SerializeField] private FloatReference _distanceToGoal;
	[SerializeField] private GameObject _goal;

	#endregion

	#region PRIVATE_VARIABLES


	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        _distanceToGoal.Value = Utilities.Instance._initDistanceToGoal - Vector2.Distance(transform.position,_goal.transform.position);
    }

	#endregion
}
