using UnityEngine;

public class DropCollectable : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	public GameObject[] _collectibles;

	private float _rarityPoolTotal;

	#endregion

	#region PRIVATE_VARIABLES


	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

	void Start()
	{
		foreach (GameObject _collectible in _collectibles)
		{
			_rarityPoolTotal += _collectible.GetComponent<CollectableBase>()._rarity;
		}
	}

	public void Drop()
	{

		float chance = Random.Range(0f, 100f);
		float totalWeight = 0;

		foreach (GameObject _collectible in _collectibles)
		{
			float weight = _collectible.GetComponent<CollectableBase>()._rarity / _rarityPoolTotal;
			totalWeight += weight;

			if (totalWeight > (chance/100))
			{
				Instantiate(_collectible
				, transform.position,
				Quaternion.identity);
				break;
			}

		}
	}

	#endregion
}
