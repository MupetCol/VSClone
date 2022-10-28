using UnityEngine;

public class MinigameSelectHandler : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	public GameObject _precisionMinigame, _scissorsMinigame, _go;

	public Chest _chest;

	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES

	[SerializeField] private float _highChance = 1f, _midChance = 5f;

	#endregion

	#region UNITY_METHODS

	public void PickedPrecision()
	{
		_go = Instantiate(_precisionMinigame);
		_go.GetComponentInChildren<ChestMinigame>()._chest = this._chest;
		Destroy(this.gameObject);
	}

	public void PickedScissors()
	{
		_go = Instantiate(_scissorsMinigame);
		_go.GetComponentInChildren<ChestMinigame>()._chest = this._chest;
		Destroy(this.gameObject);
	}

	public void Skip()
	{
		float temp = Random.Range(0f,100f);

		if(temp < _highChance)
		{
			_chest._rewardAmount = 5;
			_chest._coinMultiplier = 2f;
		}else if (temp < (_highChance + _midChance))
		{
			_chest._rewardAmount = 3;
			_chest._coinMultiplier = 1.25f;
		}
		else
		{
			_chest._rewardAmount = 1;
			_chest._coinMultiplier = 1f;
		}
		_chest.GiveReward(0f);
		Destroy(this.gameObject);
	}

	//"Can you add ""Minigame A"", ""Minigame B"" ""SKIP""  button and let the user to choose one?

	//SKIP function = Skip the minigame and rewards will be ""High = 1%, Mid = 5%, low = 94%"""

	#endregion
}
