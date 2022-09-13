using UnityEngine;

public interface IDamageable<T,U>
{
	void Damage(T damageTaken, U weaponKnockBackStat);

}
