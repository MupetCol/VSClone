using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CharacterSelectionBoxHandler : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	public PlayerCharacter[] characters;

	public ToggleGroup _charactersToggleGroup;
	public Toggle _characterSelected;


	#endregion

	#region PRIVATE_VARIABLES

	public void SetSelectedCharacter()
	{
		foreach(PlayerCharacter character in characters)
		{
			character.selected = false;
		}

		_characterSelected = _charactersToggleGroup.ActiveToggles().First();
		AssignedCharacter charSe = _characterSelected.GetComponent<AssignedCharacter>();
		charSe.character.selected = true;
	}

	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

	//public void UpdateBoxText()

	#endregion
}
