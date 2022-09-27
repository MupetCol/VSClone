using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "VS/Weapon", order = 1)]
public class Weapon : ScriptableObject
{
	#region PUBLIC_VARIABLES

	//State
	public bool equipped;

	//Stats unique to each weapon
	public float weaponLevel;
	public float maxLevel;
	public float baseDamage;
	public float cooldown;
	public float amount;
	public float pierce;
	public float poolLimit;
	public float rarity;
	public float speed;
	public float area;
	public float duration;
	public float projectInverval;
	public float hitboxDelay;
	public float knockBack;

	//Stats multipliers or additions shared globally
	public FloatReference globalAmount;
	public FloatReference globalArea;
	public FloatReference globalCooldown;
	public FloatReference globalDuration;
	public FloatReference globalMight;
	public FloatReference globalSpeed;

	#endregion

	private void OnDisable()
	{
		//equipped = false;
	}
}
