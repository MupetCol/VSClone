using UnityEngine;

public class NdujaCollectible : CollectableBase, ICollectable
{
	public NdujaFritaTantoBehavior _ndujaWeapon;

	private void Awake()
	{
		_ndujaWeapon = FindObjectOfType<NdujaFritaTantoBehavior>();
	}

	public void Collected()
	{
		_ndujaWeapon.Activate();
		Destroy(gameObject);
	}
}
