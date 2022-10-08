using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamageHandler : MonoBehaviour, IDamageable<float, float>, IKillable
{
	#region PUBLIC_VARIABLES

	public FloatReference _health;
	public bool _immortal = false;

	#endregion


	public void Damage(float damageTaken, float weaponKnockBackStat)
	{
		if (!_immortal)
		{
			_health.Value -= damageTaken;
			if (_health.Value <= 0) Kill();
		}
	}

	public void Kill()
	{
		FindObjectOfType<StageEnd>().StartEndingCor();
	}
}


