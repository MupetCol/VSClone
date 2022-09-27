using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PentagramBehavior : WeaponBase
{
	#region PRIVATE_VARIABLES

	private Collider2D _collider;
	private LayerMask _enemyLayer;

	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES

	[SerializeField] private GameObject _pentagramPanel;

	#endregion

	#region UNITY_METHODS

	public override void Awake()
	{
		base.Awake();
		_collider = GetComponent<Collider2D>();
	}

	void Start()
	{
		_enemyLayer = LayerMask.GetMask("Enemies");
		StartCoroutine(PentagramFlow());
	}

	protected IEnumerator PentagramFlow()
	{
		ContactFilter2D filter = new ContactFilter2D();
		filter.SetLayerMask(_enemyLayer);


		while (true)
		{
			List<Collider2D> colliders = new List<Collider2D>();
			Physics2D.OverlapCollider(_collider, filter, colliders);

			if (colliders.Count > 0)
			{
				_pentagramPanel.gameObject.SetActive(true);
				yield return new WaitForSeconds(.1f);
				foreach (Collider2D collider in colliders)
				{
					collider.GetComponent<IKillable>().Kill();
				}

				_pentagramPanel.gameObject.SetActive(false);
			}

			yield return new WaitForSeconds(_weaponStats.cooldown * _weaponStats.globalCooldown.Value);
			colliders.Clear();
		}
	}
	#endregion
}
