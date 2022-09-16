using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class LevelUpBehavior : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	public FloatReference _expPoints;
	public FloatReference _luck;
	public GameObject _levelUpUIPanel;
	public Button[] _options;

	public Weapon[] _weapons;

	#endregion

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
		List<Weapon> weapons = new List<Weapon>();
		foreach( Weapon weapon in _weapons)
		{
			if (!weapon.equipped)
			{
				weapons.Add(weapon);
			}
		}

		weapons[Random.Range(0, weapons.Count)].equipped = true;
	}
}
