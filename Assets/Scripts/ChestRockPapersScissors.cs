using UnityEngine;
using TMPro;

public class ChestRockPapersScissors : ChestMinigame
{
	#region PUBLIC_VARIABLES

	public int _maxRounds = 2;
	private int _currentRound = 1;

	public TMP_Text _playerPick, _machinePick, _playerScoreText, _machineScoreText, _roundText, _resultsText;

	public FloatReference _langSelected;
	public LanguageTextGroup[] _langTextOptions;
	public TMP_Text[] _texts;

	[SerializeField] private GameObject[] _disableOnOver;
	[SerializeField] private GameObject[] _enableOnOver;

	int _playerScore, _machineScore;
	public int _draws, _wins, _losses;


	#endregion

	#region PRIVATE_VARIABLES


	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

    void Start()
    {
		for (int i = 0; i < _texts.Length; i++)
		{
			_texts[i].text = _langTextOptions[(int)_langSelected.Value]._languageStrings[i];
		}
	}

    void Update()
    {
        
    }

	public void Shoot(int playerPick)
	{
		// 1 = ROCK, 2 = PAPER, 3 = SCISSORS
		int machinesPick = Random.Range(1, 4);
		if(machinesPick == 1)
		{
			_machinePick.text = "ROCK";
		}else if( machinesPick == 2)
		{
			_machinePick.text = "PAPER";
		}
		else
		{
			_machinePick.text = "SCISSORS";
		}

		if (playerPick == 1)
		{
			_playerPick.text = "ROCK";
		}
		else if (playerPick == 2)
		{
			_playerPick.text = "PAPER";
		}
		else
		{
			_playerPick.text = "SCISSORS";
		}


		if (playerPick == machinesPick)
		{
			Debug.Log("DRAW");
			_draws++;
		} else if (playerPick == 1 && machinesPick == 3 || playerPick == 2 && machinesPick == 1 || playerPick == 3 && machinesPick == 2)
		{
			Debug.Log("Player won");
			_wins++;
			_playerScore++;
			_currentRound++;
			_playerScoreText.text = _playerScore.ToString();
		}
		else
		{
			_losses++;
			Debug.Log("Machine won");
			_machineScore++;
			_currentRound++;
			_machineScoreText.text = _machineScore.ToString();
		}

		if(_currentRound > 2)
		{
			foreach(GameObject go in _disableOnOver)
			{
				go.SetActive(false);
			}

			foreach (GameObject go in _enableOnOver)
			{
				go.SetActive(true);
			}

			if(_wins == _maxRounds && _draws == 0)
			{
				_resultsText.text = "HIGH";
				SetChestAndGiveRewards(5, 2f);
			}else if(_losses > 0)
			{
				_resultsText.text = "LOW";
				SetChestAndGiveRewards(1, 1f);
			}
			else
			{
				_resultsText.text = "MID";
				SetChestAndGiveRewards(3, 1.25f);
			}
		}
		else
		{
			if(_langSelected.Value == 0)
			{
				_roundText.text = "Round " + _currentRound.ToString();
			}else if(_langSelected.Value == 1)
			{
				_roundText.text = "Ronda " + _currentRound.ToString();
			}
			else
			{
				_roundText.text = "JAPANESE " + _currentRound.ToString();
			}
			
		}
	}

	#endregion
}
