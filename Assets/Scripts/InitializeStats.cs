using UnityEngine;

public class InitializeStats : MonoBehaviour
{
	#region PUBLIC_VARIABLES
	public FloatReference[] resetNeededStats;
	public PlayerCharacter[] character;
	public Stat[] stat;

	#endregion

	#region PRIVATE_VARIABLES


	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

    void Start()
	{
		foreach (FloatReference reference in resetNeededStats)
		{
			reference.ResetValues();
		}

		foreach (PlayerCharacter character in character)
		{
			if (character.selected)
			{
				character.ApplyCharacterBonus();
				break;
			}
		}
		
		foreach (Stat stat in stat)
		{
			stat.ApplyPowerUp();
		}

		Utilities.Instance.SetMaxHealth();
    }

    void Update()
    {
        
    }

	#endregion
}
