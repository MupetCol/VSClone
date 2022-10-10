using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Stat", menuName = "VS/Stat", order = 1)]
public class Stat : ScriptableObject
{
	public FloatReference floatData;
	public float powerUpRank;
	public float bonusPerRank;
	public int stackingType;
	public float maxRank;
	public float rarity;

	public bool reset;


	[TextArea]
	public string upgradesText;

	//0 Additive - 1 MaxHealth - 2 Magnet


	public void ApplyPowerUp()
	{
		if(stackingType == 0)
		{
			floatData.Value += (powerUpRank * bonusPerRank);
		}
		else if(powerUpRank > 0)
		{
			//+1 because in the inspector i added the bonus on a bonus/100 manner
			floatData.Value *= (powerUpRank * (bonusPerRank+1));
		}
		powerUpRank++;
	}

	private void OnEnable()
	{
		if (reset)
			powerUpRank = 0;
	}


}
