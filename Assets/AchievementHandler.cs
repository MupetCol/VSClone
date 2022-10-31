using UnityEngine;
using System.Collections;
using TMPro;

public class AchievementHandler : MonoBehaviour
{
	#region PUBLIC_VARIABLES


	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES

	[SerializeField] private string[] _achievementsName;
	[SerializeField] private FloatReference[] _achievements;
    [SerializeField] private AchievementConditions[] _goals;
    [SerializeField] private Animator _animator;
    [SerializeField] private TMP_Text _achievementText;

	#endregion

	#region UNITY_METHODS

	private void Start()
	{
		for (int i = 0; i < _achievements.Length; i++)
		{
			for (int j = 0; j < _goals[i]._conditions.Length; j++)
			{
				if (_achievements[i].Value == _goals[i]._conditions[j] && !_goals[i]._goaldReached[j])
				{
					//DO SOMETHING ON THAT CONDITION
					_goals[i]._goaldReached[j] = true;
				}
			}
		}

		StartCoroutine(CheckForAchievements());
	}
	public IEnumerator CheckForAchievements()
	{
		while (true)
		{
			for (int i = 0; i < _achievements.Length; i++)
			{
				for (int j = 0; j < _goals[i]._conditions.Length; j++)
				{
					if(_achievements[i].Value == _goals[i]._conditions[j] && !_goals[i]._goaldReached[j])
					{
						//DO SOMETHING ON THAT CONDITION
						_achievementText.text = _achievementsName[i] + ": " + _goals[i]._conditions[j];
						_goals[i]._goaldReached[j] = true;
						_animator.SetTrigger("AchievementReached");
					}
				}
			}
			yield return new WaitForSeconds(1f);
		}
	}

	#endregion
}
