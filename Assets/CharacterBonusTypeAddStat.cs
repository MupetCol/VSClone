using UnityEngine;

public class CharacterBonusTypeAddStat : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	private int _timesGiven = 0;
	private float _bonusGivenOnStage = 0f;

	#endregion

	#region PRIVATE_VARIABLES


	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES

	[SerializeField] FloatReference _playerLevel;
	[SerializeField] Stat _statToAlter;
	[SerializeField] float _bonus = 0.1f;
	[SerializeField] private int _maxTimes = 5;
	[SerializeField] private float _divisorOfLevelesToApplyAt = 10f;

	#endregion

	#region UNITY_METHODS

	private void Awake()
	{
		Utilities.Instance.LeveledUp += TryBonus;
	}

	public void TryBonus()
	{
		if(_playerLevel.Value % _divisorOfLevelesToApplyAt == 0 && _timesGiven < _maxTimes)
		{
			_statToAlter.floatData.Value += _bonus;
			_bonusGivenOnStage += _bonus;
			_timesGiven++;
		}
	}

	private void OnDisable()
	{
		_statToAlter.floatData.Value -= _bonusGivenOnStage;
		Utilities.Instance.LeveledUp -= TryBonus;
	}

	#endregion
}
