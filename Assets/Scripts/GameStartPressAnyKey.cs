using UnityEngine;

public class GameStartPressAnyKey : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	[SerializeField] private GameObject[] _objectsToActivate;

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
		if (Input.anyKey)
		{
			foreach(GameObject obj in _objectsToActivate)
			{
				obj.SetActive(true);
			}
			this.gameObject.SetActive(false);
		}
    }

	#endregion
}
