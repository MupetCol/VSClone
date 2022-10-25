using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;
using TMPro;

public class ChestPrecisionMinigame : ChestMinigame
{
	#region PUBLIC_VARIABLES

	public Slider _slider;
	public float _speed;
	public Tweener _tween;
	public TMP_Text _text;
	public bool _done;
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

	private void Update()
	{
		if (Input.GetKey(KeyCode.Space) && !_done)
		{
			_done = true;
			_tween.Kill();
			DebugReward();
		}
	}

	IEnumerator startMinigame()
	{
		TweenParams tParms = new TweenParams().SetLoops(-1,LoopType.Yoyo).SetEase(Ease.Linear);
		_tween = _slider.DOValue(1f, 10f/_speed).SetAs(tParms).SetUpdate(true);
		
		yield return null;
	}

	public void DebugReward()
	{
		if(_slider.value < 0.2)
		{
			_text.text = "LOW";
			Debug.Log("LOW");
			SetChestAndGiveRewards(1, 1f);
		}
		else if(_slider.value >= .2 && _slider.value <= .3)
		{
			_text.text = "MID";
			Debug.Log("MID");
			SetChestAndGiveRewards(3, 1.25f);
		}
		else if(_slider.value > .3 && _slider.value < .475)
		{
			_text.text = "LOW";
			Debug.Log("LOW");
			SetChestAndGiveRewards(1, 1f);
		}
		else if(_slider.value >= .475 && _slider.value <= .525)
		{
			_text.text = "HIGH";
			Debug.Log("HIGH");
			SetChestAndGiveRewards(5, 2f);
		}
		else if(_slider.value > .525 && _slider.value < .7)
		{
			_text.text = "LOW";
			Debug.Log("LOW");
			SetChestAndGiveRewards(1, 1f);
		}
		else if(_slider.value >= .7 && _slider.value <= .8)
		{
			_text.text = "MID";
			Debug.Log("MID");
			SetChestAndGiveRewards(3, 1.25f);
		}
		else
		{
			_text.text = "LOW";
			Debug.Log("LOW");
			SetChestAndGiveRewards(1, 1f);
		}

	}

	#endregion
}
