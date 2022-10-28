using UnityEngine;

public class SaveRunValues : MonoBehaviour
{
	#region PUBLIC_VARIABLES
	public PlayerWeaponsHandler _player;
	public PlayerCharacterHandler _characterHandler;
	public FloatReference _time;
	public FloatReference _coinsOnStage;
	public FloatReference _xpOnHold;
	public FloatReference _xpToLevelUp;
	public FloatReference _lvl;
	public FloatReference _stage;
	public FloatReference _HP;

	public SaveFile _saveFile;

	public BoolReference _isNewFile;

	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES

	private void Start()
	{
		if (!_isNewFile.toggle)
		{
			_HP.Value = _saveFile.playerHP.Value;
			_coinsOnStage.Value = _saveFile.coinsOnHold.Value;
			_xpOnHold.Value = _saveFile.xpOnHold.Value;
			_xpToLevelUp.Value = _saveFile.xpToLevelUp.Value;
			_lvl.Value = _saveFile.playerLvl.Value;
			_time.Value = _saveFile.time.Value;
			_player.transform.position = _saveFile.playerPos.Value;
	
			//_coins.Value = _saveFile.coins.Value;
			_characterHandler._character = _saveFile.character;

			for (int i = 0; i < _saveFile.weaponLevels.values.Count; i++)
			{
				_player._weaponsObjects[i].GetComponent<WeaponBase>()._currentLevel = (int)_saveFile.weaponLevels.values[i];
			}

			foreach(Weapon wp in _saveFile.activeWeapons)
			{
				wp.equipped = true;
			}

			for (int i = 0; i < _saveFile.mapTypes.Count; i++)
			{
				Instantiate(_saveFile.mapPrefabs[_saveFile.mapTypes[i]], _saveFile.mapsPos[i], Quaternion.identity);
			}

			for (int i = 0; i < _saveFile.enemyTypes.Count; i++)
			{
				Instantiate(_saveFile.enemiesPrefabs[_saveFile.enemyTypes[i]], _saveFile.enemiesPos[i], Quaternion.identity);
			}
		}
		else
		{
			_saveFile.ResetFile();
			_coinsOnStage.Value = _saveFile.coinsOnHold.defaultValue;
			_xpOnHold.Value = _saveFile.xpOnHold.defaultValue;
			_xpToLevelUp.Value = _saveFile.xpToLevelUp.defaultValue;
			_lvl.Value = _saveFile.playerLvl.defaultValue;
			_time.Value = _saveFile.time.defaultValue;
			_player.transform.position = _saveFile.playerPos.Value;
			_player.transform.position = Vector3.zero;
			Utilities.Instance.SetMaxHealth();
		}
	}

	#endregion

	#region UNITY_METHODS

	public void SaveValues()
	{
		_saveFile._isEmpty = false;

		_saveFile.playerHP.Value = _HP.Value;
		_saveFile.coinsOnHold.Value = _coinsOnStage.Value;
		_saveFile.xpOnHold.Value = _xpOnHold.Value;
		_saveFile.xpToLevelUp.Value = _xpToLevelUp.Value;
		_saveFile.playerLvl.Value = _lvl.Value;
		_saveFile.playerPos.Value = new Vector3(_player.transform.position.x, _player.transform.position.y, _player.transform.position.z);
		_saveFile.time.Value = _time.Value;
		_saveFile.stage.Value = _stage.Value;
		_saveFile.character = _characterHandler._character;


		_saveFile.enemyTypes.Clear();
		_saveFile.enemiesPos.Clear();

		var tempMaps = FindObjectsOfType<MapType>();
		foreach (MapType map in tempMaps)
		{
			_saveFile.mapTypes.Add(map._type);
			_saveFile.mapsPos.Add(map.transform.position);
		}

		var temp = FindObjectsOfType<EnemyBehavior>();
		foreach(EnemyBehavior enemy in temp)
		{
			_saveFile.enemyTypes.Add(enemy._enemyType);
			_saveFile.enemiesPos.Add(enemy.transform.position);
		}

		_saveFile.weaponLevels.values.Clear();
		_saveFile.activeWeapons.Clear();

		foreach (GameObject weapo in _player._weaponsObjects)
		{
			_saveFile.weaponLevels.values.Add(weapo.GetComponent<WeaponBase>()._currentLevel);
			if (weapo.GetComponent<WeaponBase>()._weaponStats.equipped)
			{
				_saveFile.activeWeapons.Add(weapo.GetComponent<WeaponBase>()._weaponStats);
			}
		}
	}

	#endregion
}
