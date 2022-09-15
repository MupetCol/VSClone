using UnityEngine;

public class PlayerCharacterHandler : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	public bool _playSelectedCharacter;
	public PlayerCharacter[] _allCharacters;
	public PlayerCharacter _character;

    public bool _activateStartingWeapon = false;




	#endregion

	#region UNITY_METHODS

    void Awake()
    {
		if (_playSelectedCharacter)
		{
			foreach (PlayerCharacter chara in _allCharacters)
			{
				if (chara.selected)
				{
					_character = chara;
					break;
				}

			}
		}

		GetComponent<SpriteRenderer>().sprite = _character.sprite;

		//Activate starting weapon on start
		if (_activateStartingWeapon)
        _character.startingWeapon.equipped = true;
	}

    void Update()
    {
        
    }

	#endregion
}
