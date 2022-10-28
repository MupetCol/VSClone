using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class PowerUpShopItem : MonoBehaviour, IPointerDownHandler
{
	#region PUBLIC_VARIABLES

	public string[] _name;
	[TextArea]
	public string[] _statBonusText;
	public TMP_Text _statName;
	public TMP_Text _bonusText;
	public TMP_Text _priceText;
	
	public FloatReference _language;

	public float _basePrice;
	public float _currentPrice;
	public FloatReference _totalBought;
	public Stat _stat;

	public bool _isMaxed = false;

	private void Awake()
	{
		LanguageChanger.instance.languageAction += UpdateLanguage;
	}


	public void OnPointerDown(PointerEventData pointerEventData)
	{
		//Output the name of the GameObject that is being clicked
		_statName.text = _name[(int)_language.Value];
		_bonusText.text = _statBonusText[(int)_language.Value];
		UpdatePrice();
	}

	public void UpdateLanguage()
	{
		_bonusText.text = _statBonusText[(int)_language.Value];
	}

	public void UpdatePrice()
	{
		_currentPrice = _totalBought.Value == 0 ? _basePrice : (_basePrice * (_stat.powerUpRank + 1)) + (20 * Mathf.Pow(1.1f, _totalBought.Value));

		if(_stat.powerUpRank >= _stat.maxRank)
		{
			_priceText.text = "Maxed";
			_isMaxed = true;
		}
		else
		{
			_currentPrice -= _currentPrice % 1;
			_priceText.text = _currentPrice.ToString();
		}
	}

	private void OnDisable()
	{
		LanguageChanger.instance.languageAction -= UpdateLanguage;
	}



	#endregion

}
