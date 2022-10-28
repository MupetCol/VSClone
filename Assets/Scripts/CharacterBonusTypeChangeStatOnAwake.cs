using UnityEngine;

public class CharacterBonusTypeChangeStatOnAwake : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	#endregion

	#region PRIVATE_VARIABLES


	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES

	[SerializeField] Stat _statToAlter;
	[SerializeField] float _bonus = 0.1f;

	#endregion

	#region UNITY_METHODS

	private void Awake()
	{
		_statToAlter.floatData.Value += _bonus;
	}


	private void OnDisable()
	{
		_statToAlter.floatData.Value -= _bonus;
		
	}

	#endregion
}
