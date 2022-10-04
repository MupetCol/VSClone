using UnityEngine;
using System.Collections.Generic;

public class SetSavedCharacters : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	public List<PlayerCharacter> characterList = new List<PlayerCharacter>();
	public SaveFile _savedFile;

	#endregion

	public void SetSavedCharacter()
	{
		foreach (PlayerCharacter character in characterList)
		{
			character.selected = false;
		}
		_savedFile.character.selected = true;
	}
}
