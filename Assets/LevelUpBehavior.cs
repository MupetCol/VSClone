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
	public Weapon[] _weapons;

	#endregion

	#region PRIVATE_VARIABLES

	private List<Object> _rewardsSelected = new List<Object>();

	private float _rarityPoolTotal;


	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

	void Start()
    {
		foreach (Object obj in _rewards)
		{
			if(obj.GetType() == typeof(GameObject))
			{
				GameObject go = (GameObject)obj;
				_rarityPoolTotal += go.GetComponent<WeaponBase>()._weaponStats.rarity;
			}else if(obj.GetType() == typeof(Stat))
			{
				Stat stat = (Stat)obj;
				_rarityPoolTotal += stat.rarity;
			}
		}
	}

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
		//Temporary reward of activating a random weapon
		//List<Weapon> weapons = new List<Weapon>();
		//foreach( Weapon weapon in _weapons)
		//{
		//	if (!weapon.equipped)
		//	{
		//		weapons.Add(weapon);
		//	}
		//}
		//weapons[Random.Range(0, weapons.Count)].equipped = true;
		PickRewards();
	}

	public void PickRewards()
	{
		for (int i = 0; i < 3; i++)
		{
			float totalWeight = 0;
			float chance = Random.Range(0f, 100f);
			foreach (Object obj in _rewards)
			{
				if (obj.GetType() == typeof(GameObject))
				{
					GameObject go = (GameObject)obj;
					var rarity = go.GetComponent<WeaponBase>()._weaponStats.rarity;
					float weight = rarity / _rarityPoolTotal;
					totalWeight += weight;

					if (totalWeight > (chance / 100))
					{
						if (go.GetComponent<WeaponBase>()._weaponStats.equipped)
						{
							SetRewardOption(i, go.GetComponent<WeaponBase>().gameObject.name + " upgrade", obj);
							break;
						}
						else
						{
							SetRewardOption(i, go.GetComponent<WeaponBase>().gameObject.name, obj);
							break;
						}

					}

				}
				else if (obj.GetType() == typeof(Stat))
				{
					Stat stat = (Stat)obj;
					var rarity = stat.rarity;
					float weight = rarity / _rarityPoolTotal;
					totalWeight += weight;

					if (totalWeight > (chance / 100))
					{
						SetRewardOption(i, stat.name + "upgrade", obj);
						break;
					}
				}
			}
		}

		PauseControl.Instance.TogglePause();
		EnableOptionsUI();
	}

	public void SetRewardOption(int index, string description, Object obj)
	{
		_options[index]._optionIndex = index;
		_options[index]._text = description;
		_options[index]._reward = obj;
		_rewardsSelected.Add(obj);
	}

	public void EnableOptionsUI()
	{
		_levelUpUIPanel.SetActive(true);
	}

	//later on for owned and not owned different chances
	//public void UpdateOwnedItems()
	//{

	//}


}
