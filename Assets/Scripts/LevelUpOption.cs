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
				weapon.GetComponent<ILevelUp<float>>().LevelUp(weapon._currentLevel+1);
				if (weapon._reachedMaxLevel)
				{
					FindObjectOfType<LevelUpBehavior>()._rewards.Remove(_reward);
				}
			}
			else
			{
				weapon._weaponStats.equipped = true;
				Utilities.Instance._ownedObjects.Add(_reward);
			}
		}
		else if (_reward.GetType() == typeof(Stat))
		{
			Stat stat = (Stat)_reward;
			stat.ApplyChestPowerUp();

			if(Utilities.Instance._ownedObjects.Contains(_reward))
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
