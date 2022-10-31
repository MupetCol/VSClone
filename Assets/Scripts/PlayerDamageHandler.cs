using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerDamageHandler : MonoBehaviour, IDamageable<float, float>, IKillable
{
	#region PUBLIC_VARIABLES

	public FloatReference _health;
	public FloatReference _healthRegen;
	public FloatReference _maxHealth;
	public FloatReference _damageTakenAchievement, _deathCountAchievement;
	public bool _immortal = false;

	#endregion

	private void Start()
	{
		StartCoroutine(HealthRegeneration());
	}

	public void Damage(float damageTaken, float weaponKnockBackStat)
	{
		if (!_immortal)
		{
			_damageTakenAchievement.Value += damageTaken;
			_health.Value -= damageTaken;
			if (_health.Value <= 0) Kill();
		}
	}

	public void Kill()
	{
		_deathCountAchievement.Value++;
		FindObjectOfType<StageEnd>().GameOverCor();
	}

	public IEnumerator HealthRegeneration()
	{
		while (true)
		{
			_health.Value += _healthRegen.Value;
			_health.Value = Mathf.Clamp(_health.Value, -1, _maxHealth.Value);
			yield return new WaitForSeconds(1f);
		}
	}

	private void Update()
	{
		if (_health.Value <= 0) Kill();
	}
}


