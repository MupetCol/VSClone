using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ToggleChange : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	public Toggle[] _charactersToggles;
	public Weapon[] weapons;

	#endregion

	public void ChangeCharacterState()
	{
		foreach (Toggle toggle in _charactersToggles)
		{
			if (toggle.isOn)
			{
				toggle.GetComponent<AssignedCharacter>().character.selected = true;
			}
			else
			{
				toggle.GetComponent<AssignedCharacter>().character.selected = false;
			}
		}
	}

	public void ResetWeapons()
	{
		foreach(Weapon weapon in weapons)
		{
			weapon.equipped = false;
		}
	}
}
