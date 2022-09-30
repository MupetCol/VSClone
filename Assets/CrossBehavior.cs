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

	public override void LevelUp()
	{
		if (_reachedMaxLevel)
		{
			Debug.Log("Shouldn't have been called, already max level");
		}

		base.LevelUp();
		switch (_currentLevel)
		{
			case 2:
				baseDamage += 10;
				break;

			case 3:
				speed += .25f;
				area += .1f;
				break;

			case 4:
				amount++;
				break;

			case 5:
				baseDamage += 10;
				break;

			case 6:
				speed += .25f;
				area += .1f;
				break;

			case 7:
				amount++;
				break;

			case 8:
				baseDamage += 10;
				_reachedMaxLevel = true;
				if (Utilities.Instance._ownedObjects.Contains(this.gameObject))
				{
					Utilities.Instance._ownedObjects.Remove(this.gameObject);
				}
				break;
		}
	}
}
