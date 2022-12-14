using UnityEngine;

public class PlayerCharacterHandler : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	public bool _playSelectedCharacter;
	public PlayerCharacter[] _allCharacters;
	public PlayerCharacter _character;




	#endregion

	#region UNITY_METHODS

	private void Start()
	{
		foreach (PlayerCharacter chara in _allCharacters)
		{
			if (chara.selected)
			{
				_character = chara;
				_character.startingWeapon.equipped = true;
				break;
			}

		}
		Instantiate(_character.bonusScriptHolder);

		GetComponent<SpriteRenderer>().sprite = _character.characterSprite;
	}

 

	#endregion
}
