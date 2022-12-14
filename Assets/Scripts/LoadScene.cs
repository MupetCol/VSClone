using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
	public FloatReference _sceneIndex;
	public Animator _animator;
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
		if(_sceneIndex.Value == 0) {
			_animator.SetTrigger("IsSaveFile");
		}
		else
		{
			SceneManager.LoadScene((int)_sceneIndex.Value);
		}
	}

	public void LoadFreeScene(int index)
	{
		SceneManager.LoadScene(index);
	}
}
