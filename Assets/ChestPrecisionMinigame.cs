using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;
using TMPro;

public class ChestPrecisionMinigame : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	public Slider _slider;
	public float _speed;
	public Tweener _tween;
	public TMP_Text _text;
	#endregion

	#region PRIVATE_VARIABLES


	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

    void Start()
    {
        _slider = GetComponent<Slider>();
		StartCoroutine(startMinigame());
    }

    void Update()
    {
		if (Input.GetKey(KeyCode.Space))
		{
			_tween.Kill();
			DebugReward();
		}
    }

	IEnumerator startMinigame()
	{
		TweenParams tParms = new TweenParams().SetLoops(-1,LoopType.Yoyo).SetEase(Ease.Linear);
		_tween = _slider.DOValue(1f, 10f/_speed).SetAs(tParms);
		
		yield return null;
	}

	public void DebugReward()
	{
		if(_slider.value < 0.2)
		{
			_text.text = "LOW";
			Debug.Log("LOW");
		}else if(_slider.value >= .2 && _slider.value <= .3)
		{
			_text.text = "MID";
			Debug.Log("MID");
		}
		else if(_slider.value > .3 && _slider.value < .475)
		{
			_text.text = "LOW";
			Debug.Log("LOW");
		}
		else if(_slider.value >= .475 && _slider.value <= .525)
		{
			_text.text = "HIGH";
			Debug.Log("HIGH");
		}
		else if(_slider.value > .525 && _slider.value < .7)
		{
			_text.text = "LOW";
			Debug.Log("LOW");
		}
		else if(_slider.value >= .7 && _slider.value <= .8)
		{
			_text.text = "MID";
			Debug.Log("MID");
		}
		else
		{
			_text.text = "LOW";
			Debug.Log("LOW");
		}
	}

	#endregion
}
