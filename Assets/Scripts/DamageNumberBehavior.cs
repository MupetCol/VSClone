using UnityEngine;
using DG.Tweening;
using System.Collections;
using TMPro;

public class DamageNumberBehavior : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	public TMP_Text _text;

	#endregion

	#region PRIVATE_VARIABLES


	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

    void Start()
    {
		StartCoroutine(Flow());
    }

	IEnumerator Flow()
	{
		transform.DOScale(1.5f, 1f);
		yield return new WaitForSeconds(1f);
		var text = GetComponent<TMP_Text>();
		transform.DOScale(.75f, 1f);
		text.DOFade(0, 1f);
		yield return new WaitForSeconds(2f);
		Destroy(this);

	}

	public void UpdateText(string content)
	{
		_text.text = content;	
	}

	#endregion
}
