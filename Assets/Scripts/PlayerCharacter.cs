using UnityEngine;


[CreateAssetMenu(fileName = "Character", menuName = "VS/Character", order = 1)]
public class PlayerCharacter : ScriptableObject
{
	#region PUBLIC_VARIABLES

	public bool selected = false;
	public Weapon startingWeapon;
	public Sprite characterSprite;
	public Stat[] baseStatToChange;
	public float[] change;
	public GameObject bonusScriptHolder;


	#endregion

	public void ApplyCharacterBonus()
	{
		if (selected)
		{
			for (int i = 0; i < baseStatToChange.Length; i++)
			{
				if (baseStatToChange[i].stackingType == 0)
				{
					baseStatToChange[i].floatData.Value += change[i];
				}
				else if(baseStatToChange[i].stackingType == 1)
				{
					//Max health stat
					baseStatToChange[i].floatData.Value += change[i];
				}
				else if(baseStatToChange[i].stackingType == 2)
				{
					//Magnet stat
					baseStatToChange[i].floatData.Value *= change[i];
				}
			}
			startingWeapon.equipped = true;
		}
	}
}
