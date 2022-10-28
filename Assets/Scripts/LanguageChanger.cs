using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class LanguageChanger : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	public static LanguageChanger instance;

	public LanguageTextGroup[] _groups;
	public TMP_Text[] _textsInScene;
	public TMP_Dropdown _languageDropdown;
	public FloatReference _selectedLang;

	public Action languageAction;

	#endregion
	private void Awake()
	{
		instance = this;

	}

	private void Start()
	{
		if(_languageDropdown)
		_languageDropdown.value = (int)_selectedLang.Value;

		ChangeLanguage();
	}

	public void ChangeLanguage()
	{


		if (_languageDropdown)
		{
			int temp = _languageDropdown.value;
			_selectedLang.Value = temp;

		}

		languageAction?.Invoke();

		for (int i = 0; i < _textsInScene.Length; i++)
		{
			_textsInScene[i].text = _groups[(int)_selectedLang.Value]._languageStrings[i];
		}

	}

	
}
