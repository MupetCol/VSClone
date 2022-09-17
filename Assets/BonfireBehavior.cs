using UnityEngine;
using System.Collections;

public class BonfireBehavior : MonoBehaviour, IKillable, IDamageable<float,float>
{
	#region PUBLIC_VARIABLES

	[SerializeField] GameObject[] _collectibles;
	public float _health;
	public GameObject _collectiblePicked;
	private float _rarityPoolTotal;
	[SerializeField] private GameObject _whiteCopy;



	#endregion

	#region UNITY_METHODS

	private void Awake()
	{
		foreach (GameObject _collectible in _collectibles)
		{
			_rarityPoolTotal += _collectible.GetComponent<CollectableBase>()._rarity;
		}
		PickCollectible();
	}

	private void PickCollectible()
	{
		float chance = Random.Range(0f, 100f);
		float totalWeight = 0;

		foreach (GameObject _collectible in _collectibles)
		{
			float weight = _collectible.GetComponent<CollectableBase>()._rarity / _rarityPoolTotal;
			totalWeight += weight;

			if (totalWeight > (chance / 100))
			{
				_collectiblePicked = _collectible;
				break;
			}
		}
	}
	#endregion

	public void Damage(float damageTaken, float weaponKnockBackStat)
	{
		_health -= damageTaken;
		StartCoroutine(Flash());
		if (_health <= 0) Kill();
	}

	public void Kill()
	{
		Drop();
		Destroy(this.gameObject);
	}

	IEnumerator Flash()
	{
		_whiteCopy.SetActive(true);
		yield return new WaitForSeconds(.15f);
		_whiteCopy.SetActive(false);
	}


	private void Drop()
	{
		Instantiate(_collectiblePicked,transform.position,Quaternion.identity);
	}
}
