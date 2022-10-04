using UnityEngine;
using System.Collections.Generic;

public class RosaryFunctionHolder : MonoBehaviour
{
	#region PRIVATE_VARIABLES

	private Collider2D _collider;
	private LayerMask _enemyLayer;

	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES

	[SerializeField] private GameObject _whitePanel;

	#endregion

	#region UNITY_METHODS

	void Awake()
	{
		_collider = GetComponent<Collider2D>();
	}

	void Start()
	{
		_enemyLayer = LayerMask.GetMask("Enemies");
	}

	public void KillEnemiesOnScreen()
	{
		ContactFilter2D filter = new ContactFilter2D();
		filter.SetLayerMask(_enemyLayer);
		List<Collider2D> colliders = new List<Collider2D>();
		Physics2D.OverlapCollider(_collider, filter, colliders);

		if (colliders.Count > 0)
		{
			_whitePanel.gameObject.SetActive(true);
			foreach (Collider2D collider in colliders)
			{
				collider.GetComponent<IKillable>().Kill();
			}
			_whitePanel.gameObject.SetActive(false);
		}
	}
	#endregion
}
