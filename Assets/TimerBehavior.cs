using UnityEngine;
using TMPro;

public class TimerBehavior : MonoBehaviour
{
	#region PUBLIC_VARIABLES
	[SerializeField] private TMP_Text _timerText;
	[SerializeField] private float _time;

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
        _time += Time.deltaTime;
		DisplayTime(_time);
    }

	void DisplayTime(float timeToDisplay){
		if(timeToDisplay > 1800){
			timeToDisplay = 1800;
			FindObjectOfType<PlayerDamageHandler>().Kill();
		}

		float minutes = Mathf.FloorToInt(timeToDisplay / 60);
		float seconds = Mathf.FloorToInt(timeToDisplay % 60);

		_timerText.text = string.Format("{0:00}:{1:00}",minutes, seconds);
	}

	#endregion
}
