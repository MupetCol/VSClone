using UnityEngine;

public class PauseControl : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	public static PauseControl Instance { get; private set; }

	#endregion

	#region PRIVATE_VARIABLES

	private float previousTimeScale = 1;
	public static bool isPaused;

	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

	private void Awake()
	{
		Instance = this;
	}

	void Update()
    {
		if (Input.GetKeyDown(KeyCode.P))
		{
			TogglePause();
		}   
    }

	#endregion

	public void TogglePause()
	{
		if(Time.timeScale > 0)
		{

			previousTimeScale = Time.timeScale;
			Time.timeScale = 0;
			//AudioListener.pause = true;
			isPaused = true;

		}
		else if(Time.timeScale == 0)
		{

			previousTimeScale = Time.timeScale;
			Time.timeScale = 1;
			//AudioListener.pause = false;
			isPaused = false;

		}
	}
}


