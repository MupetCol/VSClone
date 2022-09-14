using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	public bool _playSelectedCharacter;
	public PlayerCharacter[] _allCharacters;
	public PlayerCharacter _character;

	#endregion

	#region PRIVATE_VARIABLES


	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

	private void Awake()
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
	}

	void Update()
    {
		Vector3 totalMovement = Vector3.zero;

		if (Input.GetKey(KeyCode.W))
		{
			totalMovement += transform.up;
		}

		if (Input.GetKey(KeyCode.A))
		{
			totalMovement -= transform.right;
		}

		if (Input.GetKey(KeyCode.S))
		{
			totalMovement -= transform.up;
		}

		if (Input.GetKey(KeyCode.D))
		{
			totalMovement += transform.right;
		}

		transform.Translate(totalMovement.normalized * Time.deltaTime * _character.speed);
	}

	#endregion
}
