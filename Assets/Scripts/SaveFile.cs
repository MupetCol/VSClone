using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SaveFile", menuName = "VS/SaveFile", order = 1)]
public class SaveFile : ScriptableObject
{
	#region PUBLIC_VARIABLES

	//State
	public Vector3Reference playerPos;
	public FloatReference time;
	public FloatReference stage;
	public PlayerCharacter character;
	public FloatListReference weaponLevels;
	public List<GameObject> enemiesPrefabs;
	public List<GameObject> mapPrefabs;

	public List<int> mapTypes;
	public List<Vector3> mapsPos;
	public List<int> enemyTypes;
	public List<Vector3> enemiesPos;
	public List<Weapon> activeWeapons;
	public FloatReference coinsOnHold;
	public FloatReference xpOnHold;
	public FloatReference xpToLevelUp;
	public FloatReference playerLvl;
	public FloatReference playerHP;

	public bool _manualReset;
	public bool _isEmpty;

	#endregion

	public void ResetFile()
	{
		_isEmpty = true;
		playerPos.ResetValues();
		time.ResetValues();
		weaponLevels.ResetValues();
		stage.ResetValues();
		enemyTypes.Clear();
		mapTypes.Clear();
		mapsPos.Clear();
		//DONT CLEAR
		//enemiesPrefabs.Clear();
		enemiesPos.Clear();
		activeWeapons.Clear();
		coinsOnHold.ResetValues();
		xpToLevelUp.ResetValues();
		xpOnHold.ResetValues();
		playerLvl.ResetValues();
		time.ResetValues();
	}

	private void OnEnable()
	{
		if(_manualReset) ResetFile();
	}
}
