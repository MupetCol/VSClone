using UnityEngine;

public class PlayerWeaponsHandler : MonoBehaviour
{

	#region PRIVATE_SERIALIZED_VARIABLES

	[SerializeField] private Weapon[] _weapons;
	[SerializeField] private GameObject[] _weaponsObjects;

	#endregion

	#region UNITY_METHODS

	void Start()
    {
		// Enable the starting weapon and disable the rest
		for (int i = 0; i < _weapons.Length; i++)
		{
			if (_weapons[i].equipped)
			{
				_weaponsObjects[i].SetActive(true);
			}
			else
			{
				_weaponsObjects[i].SetActive(false);
			}
		}
    }

    void Update()
    {
		// for debugging and testing weapons

		for (int i = 0; i < _weapons.Length; i++)
		{
			if (_weapons[i].equipped)
			{
				_weaponsObjects[i].SetActive(true);
			}
			else
			{
				_weaponsObjects[i].SetActive(false);
			}
		}
	}

	#endregion
}
