using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SaveFile", menuName = "VS/SaveFile", order = 1)]
public class SaveFile : ScriptableObject
{
	#region PUBLIC_VARIABLES

	//State
	public Vector3Reference playerPos;
	public FloatReference time;
	public FloatReference coins;
	public FloatReference stage;
	public PlayerCharacter character;
	public FloatListReference weaponLevels;
	public List<int> enemyTypes;
	public List<GameObject> enemiesPrefabs;
	public List<Vector3> enemiesPos;
	public List<Weapon> activeWeapons;


	#endregion

	public void ResetFile()
	{
		playerPos.ResetValues();
		time.ResetValues();
		coins.ResetValues();
		weaponLevels.ResetValues();
	}
}
