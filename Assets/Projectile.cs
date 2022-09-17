using UnityEngine;

public class Projectile : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	public Weapon _weapon;

	#endregion

	#region PRIVATE_VARIABLES


	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

    void Start()
    {
		Destroy(gameObject, _weapon.cooldown);
	}

    void Update()
    {
        
    }

	#endregion
}
