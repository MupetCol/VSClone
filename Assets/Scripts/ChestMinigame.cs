using UnityEngine;

public class ChestMinigame : MonoBehaviour
{


	public Chest _chest = new Chest();

	protected void SetChestAndGiveRewards(int rewardAmmount, float coinMultiplier)
	{
		_chest._rewardAmount = rewardAmmount;
		_chest._coinMultiplier = coinMultiplier;

		_chest.GiveReward();
	}
}
