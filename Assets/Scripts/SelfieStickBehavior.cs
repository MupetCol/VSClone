using UnityEngine;
using System.Collections;
using DG.Tweening;


public class SelfieStickBehavior : WeaponBase
{
	private float _lastArea;
	public GameObject _stickParent;
	public GameObject _stick;
	public GameObject _cellphone;
	public GameObject _flash;

	public Vector3 _stickLength = new Vector3(1.5f, 0.15f, 1f);
	public Vector3 _flashLength = new Vector3(2.2f, 2.2f, 2.2f);

	#region UNITY_METHODS

	void Start()
	{
		StartCoroutine(SelfieStick());
		_lastArea = _weaponStats.area + _weaponStats.globalArea.Value;
	}

	IEnumerator SelfieStick()
	{
		while (true)
		{
			if (_lastArea != _weaponStats.area + _weaponStats.globalArea.Value)
			{
				_flashLength *= _weaponStats.area * _weaponStats.globalArea.Value;
			}
			_stickParent.SetActive(true);
			_stick.transform.DOScale(_stickLength, 1f).SetEase(Ease.Linear);
			yield return new WaitForSeconds(1f);
			_cellphone.SetActive(true);
			_flash.transform.DOScale(_flashLength,1f);
			yield return new WaitForSeconds(1f);
			_cellphone.transform.DOLocalRotate(new Vector3(0, 0, -270), 1f, RotateMode.FastBeyond360);
			yield return new WaitForSeconds(4f);
			_stickParent.SetActive(false);
			_cellphone.SetActive(false);
			ResetValues();


			yield return new WaitForSeconds(cooldown / _weaponStats.globalCooldown.Value);
		}

	}

	void ResetValues()
	{
		_flash.transform.localScale = Vector3.zero;
		_stick.transform.localScale = Vector3.zero;
		_cellphone.transform.DORotate(Vector3.zero, 0.1f);
	}

	public override void LevelUp(int level)
	{
		if (_reachedMaxLevel)
		{
			Debug.Log("Shouldn't have been called, already max level");
		}

		// TO BE CHANGED LATER
		base.LevelUp(level);
		switch (level)
		{
			case 2:
				baseDamage += 10;
				break;

			case 3:
				cooldown -= .2f; //should rest .2seconds, not percent based
				break;

			case 4:
				baseDamage += 10;
				break;

			case 5:
				baseDamage += 10;
				break;

			case 6:
				cooldown -= .2f;
				break;

			case 7:
				area += .2f;
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

	#endregion
}
