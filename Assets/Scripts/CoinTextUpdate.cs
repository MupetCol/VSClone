using UnityEngine;
using TMPro;

public class CoinTextUpdate : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	public FloatReference _coins;

	private TMP_Text _text;

	#endregion

	#region PRIVATE_VARIABLES


	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

	private void Awake()
	{
		_text = GetComponent<TMP_Text>();
	}

	void Update()
    {
        _text.text = _coins.Value.ToString();
    }

	#endregion
}
