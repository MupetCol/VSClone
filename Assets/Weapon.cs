using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Status", menuName = "VS/Weapon", order = 1)]
public class Weapon : ScriptableObject
{
	#region PUBLIC_VARIABLES
	public bool equipped;
	public int weaponLevel;

	#endregion


}
