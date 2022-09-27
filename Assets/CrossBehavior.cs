using UnityEngine;
using System.Collections;

public class CrossBehavior : WeaponBase
{
	#region PUBLIC_VARIABLES

	public CrossProjectile _projectile;
	public float _radius = 3f;

	#endregion

	#region PRIVATE_VARIABLES

	private LayerMask _enemyLayerMask;

	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

    void Start()
    {
        _enemyLayerMask = LayerMask.GetMask("Enemies");
        StartCoroutine(CrossFlow());
    }

    IEnumerator CrossFlow()
    {
	    while (true)
	    {
		    for (int i = 0; i < amount + _weaponStats.globalAmount.Value; i++)
		    {
			    CrossProjectile project = Instantiate(_projectile, transform.position, Quaternion.identity);
			    project.SetDirection(DetectClosestEnemy(), transform.position);
			    yield return new WaitForSeconds(_weaponStats.projectInverval);
		    }
		    yield return new WaitForSeconds(cooldown / _weaponStats.globalSpeed.Value);
	    }
    }

    private Transform DetectClosestEnemy()
    {

	    Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, _radius, _enemyLayerMask);

	    if (enemies.Length > 0)
	    {
		    float distance = 10000f;
		    Transform target = null;

		    foreach (Collider2D enemy in enemies)
		    {
			    if (Vector3.Distance(transform.position, enemy.transform.position) < distance)
			    {
				    target = enemy.transform;
			    }
		    }

		    return target;
	    }

	    return null;

	    //OnDrawGizmosSelected();
    }

	#endregion
}
