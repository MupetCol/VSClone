using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamageHandler : MonoBehaviour, IDamageable<float, float>, IKillable
{
	#region PUBLIC_VARIABLES

	public FloatReference _health;

	#endregion


	public void Damage(float damageTaken, float weaponKnockBackStat)
	{
		_health.Value -= damageTaken;
		if (_health.Value <= 0) Kill();
	}

	public void Kill()
	{
		Destroy(this.gameObject);
		SceneManager.LoadScene(0);
	}
}


