using UnityEngine;

public class OnGameExit : MonoBehaviour
{
	public BoolReference _firstOpeningGame;

	private void OnApplicationQuit()
	{
		_firstOpeningGame.toggle = false;
	}
}
