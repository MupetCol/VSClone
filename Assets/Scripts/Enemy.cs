using UnityEngine;


[CreateAssetMenu(fileName = "EnemyName", menuName = "VS/Enemy", order = 1)]
public class Enemy : ScriptableObject
{
	#region PUBLIC_VARIABLES

	public float baseHealth;
	public float power;
	public float speed;
	public float knockback;
	public float xp;

	public bool hpXlevel;


	#endregion

	#region PRIVATE_VARIABLES


	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

    void Start()
    {
        
    }

    void Update()
    {
        
    }

	#endregion
}
