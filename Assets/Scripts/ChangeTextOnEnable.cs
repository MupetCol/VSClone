using UnityEngine;
using TMPro;

public class ChangeTextOnEnable : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	public StringReference _description;

	#endregion

	#region PRIVATE_VARIABLES

	private TMP_Text _text;

	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

    void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

	private void OnEnable()
	{
		_text.text = _description.description;
	}

	#endregion
}
