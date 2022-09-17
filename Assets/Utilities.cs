using UnityEngine;
using System.Collections.Generic;

public class Utilities : MonoBehaviour
{
	public static Utilities Instance { get; private set; }
	public float _maxHealth = 0;
	public float _expToLevelUp = 15f;
	public FloatReference _health;
	public List<Object> _ownedObjects = new List<Object>();
	#region PUBLIC_VARIABLES


	#endregion

	#region PRIVATE_VARIABLES


	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



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
    }

    void Update()
    {
        
    }

	#endregion
}
