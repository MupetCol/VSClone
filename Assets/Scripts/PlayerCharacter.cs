using UnityEngine;


[CreateAssetMenu(fileName = "Character", menuName = "VS/Character", order = 1)]
public class PlayerCharacter : ScriptableObject
{
	#region PUBLIC_VARIABLES

	public bool selected = false;
	public Weapon startingWeapon;
	public Sprite characterSprite;
	public Stat[] baseStatToBoost;
	public float[] bonus;
	public GameObject bonusScriptHolder;


	#endregion

	public void ApplyCharacterBonus()
	{
		if (selected)
		{
			for (int i = 0; i < baseStatToBoost.Length; i++)
			{
				if (baseStatToBoost[i].stackingType == 0)
				{
					baseStatToBoost[i].floatData.Value += bonus[i];
				}
				else if(baseStatToBoost[i].stackingType == 1)
				{
					//Max health stat
					baseStatToBoost[i].floatData.Value += bonus[i];
				}
				else if(baseStatToBoost[i].stackingType == 2)
				{
					//Magnet stat
					baseStatToBoost[i].floatData.Value *= bonus[i];
				}
			}
			startingWeapon.equipped = true;
		}
	}
}
