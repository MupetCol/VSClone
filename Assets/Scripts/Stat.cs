using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Stat", menuName = "VS/Stat", order = 1)]
public class Stat : ScriptableObject
{
	public FloatReference baseStat;
	public float powerUpRank;
	public float bonusPerRank;
	public float maxCap;

	//0 Additive - 1 MaxHealth - 2 Magnet
	public int stackingType;


	public void ApplyPowerUp()
	{
		if(stackingType == 0)
		{
			baseStat.Value += (powerUpRank * bonusPerRank);
		}
		else if(powerUpRank > 0)
		{
			//+1 because in the inspector i added the bonus on a bonus/100 manner
			baseStat.Value *= (powerUpRank * (bonusPerRank+1));
		}
	}


}
