using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour, IDamageable<float, float>, IKillable
{
	#region PUBLIC_VARIABLES

	public bool _playSelectedCharacter;
	public PlayerCharacter[] _allCharacters;
	public PlayerCharacter _character;

	#endregion

	#region UNITY_METHODS

	void Awake()
	{
		if (_playSelectedCharacter)
		{
			foreach (PlayerCharacter chara in _allCharacters)
			{
				if (chara.selected)
				{
					_character = chara;
					break;
				}
			}
		}
		_character.currHealth = _character.maxHealth;
	}
	#endregion

	public void Damage(float damageTaken, float weaponKnockBackStat)
	{
		_character.currHealth -= damageTaken;
		if (_character.currHealth <= 0) Kill();
	}

	public void Kill()
	{
		Destroy(this.gameObject);
		SceneManager.LoadScene(0);
	}
}


