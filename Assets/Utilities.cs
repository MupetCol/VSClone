using UnityEngine;
using System.Collections.Generic;

public class Utilities : MonoBehaviour
{

	#region PUBLIC_VARIABLES

	public static Utilities Instance { get; private set; }
	public float _maxHealth = 0;
	public float _expToLevelUp = 15f;
	public float _initDistanceToGoal = 0f;
	public FloatReference _health;
	public List<Object> _ownedObjects = new List<Object>();

	public GameObject _goal;

	#endregion

	#region UNITY_METHODS

	public void SetMaxHealth()
	{
		_maxHealth = _health.Value;
		_expToLevelUp = 5f;
	}
    void Awake()
    {
        Instance = this;
		_initDistanceToGoal = Vector2.Distance(transform.position, _goal.transform.position);
    }

    void Update()
    {
        
    }

	#endregion
}
