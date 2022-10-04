using UnityEngine;

public class SetMapGeneratorStartingPoint : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	private Vector3 _currentPoint;
	private InfiniteMapGenerator _generator;

	#endregion

	#region PRIVATE_VARIABLES


	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES


	private void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "MapCenter"){
			_currentPoint = other.transform.position;
			_generator._startingPos = _currentPoint;
		}
	}
	#endregion

	#region UNITY_METHODS

    private void Awake() {
		_generator = FindObjectOfType<InfiniteMapGenerator>();
	}

    void Update()
    {
        
    }

	#endregion
}
