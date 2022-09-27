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
	    transform.localScale *= _weapon.area * _weapon.globalArea.Value;
		Destroy(gameObject, _weapon.duration * _weapon.globalDuration.Value);
	}

    void Update()
    {
        
    }

	#endregion
}
