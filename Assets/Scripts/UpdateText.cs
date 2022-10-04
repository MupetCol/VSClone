using UnityEngine;
using TMPro;

public class UpdateText : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	public FloatReference _floatToGive;
	TMP_Text _text;

	#endregion

	#region PRIVATE_VARIABLES


	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

    void Start()
    {
		_text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        _text.text = _floatToGive.Value.ToString();
    }

	#endregion
}
