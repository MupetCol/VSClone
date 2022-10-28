using UnityEngine;

public class GameStartPressAnyKey : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	[SerializeField] private GameObject[] _objectsToActivate;
	[SerializeField] private BoolReference _firstOpeningGame;

	#endregion

	#region UNITY_METHODS

    void Start()
    {
        if(_firstOpeningGame.toggle == true)
		{
			ActivateObjects();
		}
    }

    void Update()
    {
		if (Input.anyKey && _firstOpeningGame.toggle == false)
		{
			ActivateObjects();
		}
    }

	private void ActivateObjects()
	{
		foreach (GameObject obj in _objectsToActivate)
		{
			obj.SetActive(true);
		}
		this.gameObject.SetActive(false);
		_firstOpeningGame.toggle = true;
	}

	#endregion
}
