using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class LevelUpBehavior : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	public FloatReference _expPoints;
	public FloatReference _luck;
	public GameObject _levelUpUIPanel;
	public LevelUpOption[] _options;
	public List<Object> _rewards;

	#endregion

	#region PRIVATE_VARIABLES

	private List<Object> _rewardsSelected = new List<Object>();

	private float _rarityPoolRewards;
	private float _rarityPoolOwnedObjects;

	private int _currLevel = 1;


	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS


    void Update()
    {
        if(_expPoints.Value > Utilities.Instance._expToLevelUp)
		{
			_expPoints.Value = _expPoints.Value% Utilities.Instance._expToLevelUp;
			Utilities.Instance._expToLevelUp += 10;
			LevelUp();
		}
    }

	#endregion

	public void LevelUp()
	{
		_currLevel++;
		PickRewards();
	}

	public void PickRewards()
	{
		// GENERATE RARITY POOLS FOR BOTH REWARDS AND OWNED ITEMS
		_rarityPoolOwnedObjects = 0;
		_rarityPoolRewards = 0;

		foreach (Object obj in _rewards)
		{
			if (obj.GetType() == typeof(GameObject))
			{
				GameObject go = (GameObject)obj;
				_rarityPoolRewards += go.GetComponent<WeaponBase>()._weaponStats.rarity;
			}
			else if (obj.GetType() == typeof(Stat))
			{
				Stat stat = (Stat)obj;
				_rarityPoolRewards += stat.rarity;
			}
		}

		foreach (Object obj in Utilities.Instance._ownedObjects)
		{
			if (obj.GetType() == typeof(GameObject))
			{
				GameObject go = (GameObject)obj;
				_rarityPoolOwnedObjects += go.GetComponent<WeaponBase>()._weaponStats.rarity;
			}
			else if (obj.GetType() == typeof(Stat))
			{
				Stat stat = (Stat)obj;
				_rarityPoolOwnedObjects += stat.rarity;
			}
		}

		//////////

		int totalRewards = 3;
		int ownedItemsRewards = 0;

		float ownedObjectChance = 1f + (0.3f * _currLevel) - (1f / _luck.Value);

		for (int i = 0; i < 2; i++)
		{
			float chance = Random.Range(0f, 100f);
			if(ownedObjectChance > chance) ownedItemsRewards++;
		}

		// RANDOM IN OWNED OBJECTS
		for (int i = 0; i < ownedItemsRewards; i++)
		{
			float totalWeight = 0;
			float chance = Random.Range(0f, 100f);
			foreach (Object obj in Utilities.Instance._ownedObjects)
			{
				if (obj.GetType() == typeof(GameObject))
				{
					GameObject go = (GameObject)obj;
					var rarity = go.GetComponent<WeaponBase>()._weaponStats.rarity;
					float weight = rarity / _rarityPoolOwnedObjects;
					totalWeight += weight;

					if (totalWeight > (chance / 100))
					{
						if (_rewardsSelected.Contains(obj))
						{
							ownedItemsRewards--;
							break;
						}
						else
						{
							_rewardsSelected.Add(obj);
							break;
						}
					}

				}
				else if (obj.GetType() == typeof(Stat))
				{
					Stat stat = (Stat)obj;
					var rarity = stat.rarity;
					float weight = rarity / _rarityPoolOwnedObjects;
					totalWeight += weight;

					if (totalWeight > (chance / 100))
					{
						if (_rewardsSelected.Contains(obj))
						{
							ownedItemsRewards--;
							break;
						}
						else
						{
							_rewardsSelected.Add(obj);
							break;
						}
					}
				}
			}
		}


		// RANDOM BETWEEN ALL REWARDS, TAKES ACCOUNT OF RARITY INDIVIDUALLY
		for (int i = 0; i < totalRewards - ownedItemsRewards; i++)
		{
			float totalWeight = 0;
			float chance = Random.Range(0f, 100f);
			foreach (Object obj in _rewards)
			{
				if (obj.GetType() == typeof(GameObject))
				{
					GameObject go = (GameObject)obj;
					var rarity = go.GetComponent<WeaponBase>()._weaponStats.rarity;
					float weight = rarity / _rarityPoolRewards;
					totalWeight += weight;

					if (totalWeight > (chance / 100))
					{
						if (go.GetComponent<WeaponBase>()._weaponStats.equipped)
						{
							if (_rewardsSelected.Contains(obj))
							{
								totalRewards++;
								break;
							}
							else
							{
								_rewardsSelected.Add(obj);
								break;
							}
						}
						else
						{
							if (_rewardsSelected.Contains(obj))
							{
								totalRewards++;
								break;
							}
							else
							{
								_rewardsSelected.Add(obj);
								break;
							}
						}

					}

				}
				else if (obj.GetType() == typeof(Stat))
				{
					Stat stat = (Stat)obj;
					var rarity = stat.rarity;
					float weight = rarity / _rarityPoolRewards;
					totalWeight += weight;

					if (totalWeight > (chance / 100))
					{
						if (_rewardsSelected.Contains(obj))
						{
							totalRewards++;
							break;
						}
						else
						{
							_rewardsSelected.Add(obj);
							break;
						}
					}
				}
			}
		}


		for (int i = 0; i < _rewardsSelected.Count; i++)
		{
			SetRewardOption(i, _rewardsSelected[i].name, _rewardsSelected[i]);
		}



		PauseControl.Instance.TogglePause();
		EnableOptionsUI();
		_rewardsSelected.Clear();
	}

	public void SetRewardOption(int index, string description, Object obj)
	{
		_options[index]._optionIndex = index;
		_options[index]._text = description;
		_options[index]._reward = obj;
	}

	public void EnableOptionsUI()
	{
		_levelUpUIPanel.SetActive(true);
	}

}
