using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WhipBehavior : WeaponBase
{
	private float _lastArea;

	#region UNITY_METHODS

	void Start()
	{
		StartCoroutine(WhipFlow());
		_lastArea = _weaponStats.area + _weaponStats.globalArea.Value;
	}

	IEnumerator WhipFlow()
	{
		while (true)
		{
			if (_lastArea != _weaponStats.area + _weaponStats.globalArea.Value)
			{
				for (int i = 0; i < transform.childCount; i++)
				{
					transform.GetChild(i).localScale *= _weaponStats.area * _weaponStats.globalArea.Value;
					_lastArea = _weaponStats.area + _weaponStats.globalArea.Value;		
				}
			}
				

			for (int i = 0; i < amount + _weaponStats.globalAmount.Value; i++)
			{
				int childs = Mathf.Clamp(i, 0, 3);
				var child = transform.GetChild(childs);

				//Set scale if global area stat has changed
				if(_lastArea != _weaponStats.area + _weaponStats.globalArea.Value)
				child.localScale *= _weaponStats.area * _weaponStats.globalArea.Value;
				_lastArea = _weaponStats.area + _weaponStats.globalArea.Value;

				child.gameObject.SetActive(true);
				Collider2D col = child.GetComponent<Collider2D>();

				// Deal damage to enemies
				yield return new WaitForSeconds(_weaponStats.projectInverval);
				child.gameObject.SetActive(false);
			}
			yield return new WaitForSeconds(cooldown/_weaponStats.globalCooldown.Value);
		}

	}

	#endregion
}
