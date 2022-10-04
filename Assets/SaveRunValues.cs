using UnityEngine;

public class SaveRunValues : MonoBehaviour
{
	#region PUBLIC_VARIABLES
	public PlayerWeaponsHandler _player;
	public PlayerCharacterHandler _characterHandler;
	public FloatReference _time;
	public FloatReference _coins;
	public FloatReference _stage;

	public SaveFile _saveFile;

	public BoolReference _isNewFile;

	#endregion

	#region PRIVATE_VARIABLES


	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES

	private void Awake()
	{
		if (!_isNewFile.toggle)
		{
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

			for (int i = 0; i < _saveFile.enemyTypes.Count; i++)
			{
				Instantiate(_saveFile.enemiesPrefabs[_saveFile.enemyTypes[i]], _saveFile.enemiesPos[i], Quaternion.identity);
			}
		}
	}

	#endregion

	#region UNITY_METHODS

	public void SaveValues()
	{
		_saveFile.playerPos.Value = new Vector3(_player.transform.position.x, _player.transform.position.y, _player.transform.position.z);
		_saveFile.time.Value = _time.Value;
		_saveFile.coins.Value = _coins.Value;
		_saveFile.stage.Value = _stage.Value;
		_saveFile.character = _characterHandler._character;


		_saveFile.enemyTypes.Clear();
		_saveFile.enemiesPos.Clear();

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
