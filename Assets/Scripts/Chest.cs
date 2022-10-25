using UnityEngine;
using System.Collections;

public class Chest : CollectableBase, ICollectable
{
	public float _value;
	public BoolReference _uiToggle;
	public FloatReference _coins;
	public StringReference _coinsNumber, _rewardGiven;
	public float _popUpTime;

	public GameObject _rockPapersScissorsMinigame, _precisionMinigame, go;
	public int _rewardAmount = 1;
	public float _coinMultiplier = 1f;

	private Object _reward;


	public void Collected()
	{
		var temp = Random.Range(0, 2);

		if(temp == 0)
		{
			go = Instantiate(_rockPapersScissorsMinigame);
			go.GetComponentInChildren<ChestMinigame>()._chest = this;

		}
		else
		{
			go = Instantiate(_precisionMinigame);
			go.GetComponentInChildren<ChestMinigame>()._chest = this;
		}
		PauseControl.Instance.TogglePause();
	}

	public void GiveReward()
	{
		GetComponent<SpriteRenderer>().enabled = false;
		GetComponent<Collider2D>().enabled = false;
		_rewardGiven.description = " ";

		for (int i = 0; i < _rewardAmount; i++)
		{
			if(Utilities.Instance._ownedObjects.Count > 1)
			{
				 _reward = Utilities.Instance._ownedObjects[Random.Range(0, Utilities.Instance._ownedObjects.Count)];
			}else if (Utilities.Instance._ownedObjects.Count == 0)
			{
				break;
			}
			else
			{
				 _reward = Utilities.Instance._ownedObjects[0];
			}

			if (_reward.GetType() == typeof(GameObject))
			{
				GameObject go = (GameObject)_reward;
				WeaponBase weapon = go.GetComponent<WeaponBase>();
				weapon.GetComponent<ILevelUp<float>>().LevelUp(weapon._currentLevel + 1);
				_rewardGiven.description +=  weapon.name + ", ";
			}
			else if (_reward.GetType() == typeof(Stat))
			{
				Stat stat = (Stat)_reward;
				stat.floatData.Value += stat.bonusPerRank;
				_rewardGiven.description += stat.name + ", ";
			}

		}
		_rewardGiven.description += " Upgraded";
		int coinReward = Random.Range(0, 101);
		_coins.Value += (coinReward * _coinMultiplier);
		_coinsNumber.description = (coinReward * _coinMultiplier).ToString();

		StartCoroutine(StatusChangeUI());
	}

	IEnumerator StatusChangeUI()
	{
		yield return new WaitForSecondsRealtime(3f);
		Destroy(go);
		_uiToggle.toggle = true;
		yield return new WaitForSecondsRealtime(_popUpTime);
		PauseControl.Instance.TogglePause();
		_uiToggle.toggle = false;
		_rewardGiven.description = " ";
		Destroy(gameObject);
	}
}
