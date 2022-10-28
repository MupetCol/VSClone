using UnityEngine;
using System.Collections;

public class ChestMinigame : MonoBehaviour
{


	public Chest _chest;
	public GameObject _parent;

	protected void SetChestAndGiveRewards(int rewardAmmount, float coinMultiplier)
	{
		StartCoroutine(GiveRewards(rewardAmmount, coinMultiplier));
	}

	public IEnumerator GiveRewards(int rewardAmmount, float coinMultiplier)
	{
		_chest._rewardAmount = rewardAmmount;
		_chest._coinMultiplier = coinMultiplier;
		_chest.GiveReward(3f);
		yield return new WaitForSecondsRealtime(3f);
		Destroy(_parent);
	}
}
