using UnityEngine;
using System.Collections;

public class Chest : CollectableBase, ICollectable
{
	public float _value;
	public BoolReference _uiToggle;
	public FloatReference _coins;
	public StringReference _coinsNumber, _rewardGiven;


	public void Collected()
	{
		GetComponent<SpriteRenderer>().enabled = false;
		GetComponent<Collider2D>().enabled = false;

		Object _reward = Utilities.Instance._ownedObjects[Random.Range(0, Utilities.Instance._ownedObjects.Count)];
		if (_reward.GetType() == typeof(GameObject))
		{
			GameObject go = (GameObject)_reward;
			WeaponBase weapon = go.GetComponent<WeaponBase>();
			if (weapon._weaponStats.equipped)
			{
				weapon.baseDamage += 10;
				_rewardGiven.description = weapon.name + " Upgraded";
			}
			else
			{
				weapon._weaponStats.equipped = true;
				_rewardGiven.description = weapon.name + " Equipped";
			}
		}
		else if (_reward.GetType() == typeof(Stat))
		{
			Stat stat = (Stat)_reward;
			stat.baseStat.Value += stat.bonusPerRank;
			_rewardGiven.description = stat.name + " Upgraded";
		}

		int coinReward = Random.Range(0, 101);
		_coins.Value += coinReward;
		_coinsNumber.description = coinReward.ToString();

		StartCoroutine(StatusChangeUI());
	}

	IEnumerator StatusChangeUI()
	{
		_uiToggle.toggle = true;
		PauseControl.Instance.TogglePause();

		yield return new WaitForSecondsRealtime(5f);
		PauseControl.Instance.TogglePause();
		_uiToggle.toggle = false;
		Destroy(gameObject);
	}
}
