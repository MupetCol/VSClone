using UnityEngine;
using TMPro;

public class LevelUpOption : MonoBehaviour
{
	#region PUBLIC_VARIABLES
	public int _optionIndex;
	public string _text;
	public Object _reward;

	#endregion

	private void OnEnable()
	{
		GetComponentInChildren<TMP_Text>().text = _text;
	}

	public void GiveReward()
	{
		if (_reward.GetType() == typeof(GameObject))
		{
			GameObject go = (GameObject)_reward;
			WeaponBase weapon = go.GetComponent<WeaponBase>();
			if (weapon._weaponStats.equipped)
			{
				weapon.baseDamage += 10;
			}
			else
			{
				weapon._weaponStats.equipped = true;
			}
			if (!Utilities.Instance._ownedObjects.Contains(_reward))
				Utilities.Instance._ownedObjects.Add(_reward);
		}
		else if (_reward.GetType() == typeof(Stat))
		{
			Stat stat = (Stat)_reward;
			stat.floatData.Value += stat.bonusPerRank;

			if(!Utilities.Instance._ownedObjects.Contains(_reward))
			Utilities.Instance._ownedObjects.Add(_reward);
		}
		PauseControl.Instance.TogglePause();
	}

	#region PRIVATE_VARIABLES


	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

	void Start()
    {
        
    }

    void Update()
    {
        
    }

	#endregion
}
