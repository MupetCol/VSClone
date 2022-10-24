using UnityEngine;
using TMPro;

public class ChestRockPapersScissors : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	public int _maxRounds = 2;
	private int _currentRound = 1;

	public TMP_Text _playerPick, _machinePick, _playerScoreText, _machineScoreText, _roundText, _resultsText;

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
			}else if(_losses > 0)
			{
				_resultsText.text = "LOW";
			}
			else
			{
				_resultsText.text = "MID";
			}
		}
		else
		{
			_roundText.text = "Round " + _currentRound.ToString();
		}
	}

	#endregion
}
