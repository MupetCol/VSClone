using UnityEngine;
using System.Collections.Generic;
using System;

public class Utilities : MonoBehaviour
{

	#region PUBLIC_VARIABLES

	public static Utilities Instance { get; private set; }
	public FloatReference _expToLevelUp;
	public FloatReference _playerLevel;
	public float _initDistanceToGoal = 0f;
	public FloatReference _maxHealth;
	public FloatReference _currHealth;
	public List<UnityEngine.Object> _ownedObjects = new List<UnityEngine.Object>();
	public List<EnemyBehavior> _enemies = new List<EnemyBehavior>();
	public List<ExpGem> _expGems = new List<ExpGem>();
	
	public Transform _player;

	public GameObject _goal;

	public Action LeveledUp;

	#endregion

	#region UNITY_METHODS

	public void SetMaxHealth()
	{
		_currHealth.Value = _maxHealth.Value;
	}
    void Awake()
    {
		_player = FindObjectOfType<PlayerMovement>().transform;
        Instance = this;
		_initDistanceToGoal = Vector2.Distance(transform.position, _goal.transform.position);
    }


	void Update()
    {
        
    }

	#endregion
}
