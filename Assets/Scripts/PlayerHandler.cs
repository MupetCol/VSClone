using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	public PlayerCharacter _character;
    public bool _activateStartingWeapon = false;


	#endregion

	#region UNITY_METHODS

    void Awake()
    {
        //Activate starting weapon on start
        if(_activateStartingWeapon)
        _character.startingWeapon.equipped = true;
    }

    void Update()
    {
        
    }

	#endregion
}
