using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
public class RefundPowerUps : MonoBehaviour
{
	#region PUBLIC_VARIABLES

    public List<Stat> _statsList = new List<Stat>();
    public List<PowerUpShopItem> _items = new List<PowerUpShopItem>();
    public FloatReference _totalBought;
    public FloatReference _coinsHolded;
    public FloatReference _spentCoinsStack;

    public ToggleGroup _itemsToggles;
    public Toggle _toggleSelected;

    #endregion


    #region UNITY_METHODS

    public void ResetPowerUps()
	{
        foreach(Stat stat in _statsList)
		{
            stat.floatData.Value = stat.floatData.defaultValue;
            stat.powerUpRank = 0;
        }

        _coinsHolded.Value += _spentCoinsStack.Value;
        _spentCoinsStack.Value = 0;
        _totalBought.Value = 0;

        foreach (PowerUpShopItem item in _items)
        {
            item.UpdatePrice();
        }

        _toggleSelected = _itemsToggles.ActiveToggles().FirstOrDefault();
        _toggleSelected.GetComponent<PowerUpShopItem>().UpdatePrice();
    }

	#endregion
}
