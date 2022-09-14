using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "VS/Weapon", order = 1)]
public class Weapon : ScriptableObject
{
	#region PUBLIC_VARIABLES

	//State
	public bool equipped;

	//Stats
	public int weaponLevel;
	public int maxLevel;
	public int baseDamage;
	public int cooldown;
	public int amount;
	public int pierce;
	public int poolLimit;
	public int rarity;

	public float speed;
	public float area;
	public float duration;
	public float projectInverval;
	public float hitboxDelay;
	public float knockBack;


	#endregion

	private void OnDisable()
	{
		equipped = false;
	}
}
