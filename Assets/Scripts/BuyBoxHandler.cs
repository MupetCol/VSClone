using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class BuyBoxHandler : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	public FloatReference _coinsHolded;
	public FloatReference _spentCoinsStack;
	public FloatReference _totalBought;

	public ToggleGroup _items;
	public Toggle _itemBought;


	#endregion

	#region PRIVATE_VARIABLES

	public void Buy()
	{
		
		_itemBought = _items.ActiveToggles().FirstOrDefault();
		PowerUpShopItem itemSelected = _itemBought.GetComponent<PowerUpShopItem>();
		if (_coinsHolded.Value >= itemSelected._currentPrice)
		{
			_coinsHolded.Value -= itemSelected._currentPrice + (itemSelected._currentPrice % 1);
			_spentCoinsStack.Value += itemSelected._currentPrice + (itemSelected._currentPrice % 1);
			_totalBought.Value++;
			itemSelected._stat.ApplyPowerUp();

			itemSelected.UpdatePrice();
		}
	}

	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

	//public void UpdateBoxText()

	#endregion
}
