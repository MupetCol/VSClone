using UnityEngine;


[CreateAssetMenu(fileName = "Character", menuName = "VS/Character", order = 1)]
public class PlayerCharacter : ScriptableObject
{
	#region PUBLIC_VARIABLES
	public float maxHealth = 0;
	public float currHealth = 0;
	public float speed = 1;
	public Weapon startingWeapon;
	public int characterBonus = 0;

	public bool selected = false;

	public Sprite sprite;



	#endregion

	private void OnEnable()
	{
		currHealth = maxHealth;
		//startingWeapon.equipped = true;
	}

	private void OnDisable()
	{
		selected = false;
	}
}
