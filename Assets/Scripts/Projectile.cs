using UnityEngine;

public class Projectile : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	public Weapon _weapon;
	public bool _projectileCustomDestroyTime;
	public float _destroyTime;

	#endregion

	#region PRIVATE_VARIABLES


	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

    void Start()
    {
	    transform.localScale *= _weapon.area * _weapon.globalArea.Value;
		if (!_projectileCustomDestroyTime)
		{
			Destroy(gameObject, _weapon.duration * _weapon.globalDuration.Value);
		}
		else
		{
			Destroy(gameObject, _destroyTime);
		}
	}

    void Update()
    {
        
    }

	#endregion
}
