using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
	public FloatReference _sceneIndex;
	#region PUBLIC_VARIABLES


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

	#endregion

	public void LoadSceneByIndex()
	{
		SceneManager.LoadScene((int)_sceneIndex.Value);
	}
}
