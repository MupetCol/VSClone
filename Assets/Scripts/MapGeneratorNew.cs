using UnityEngine;

public class MapGeneratorNew : MonoBehaviour
{
	#region PUBLIC_VARIABLES
	

	#endregion

	#region PRIVATE_VARIABLES


	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES
	 LayerMask _mask;
	[SerializeField] private GameObject _startMap;
	[SerializeField] private GameObject[] _maps;
	#endregion

	#region UNITY_METHODS

    void Start()
    {
		_mask = LayerMask.GetMask("Maps");
		foreach (Transform child in _startMap.transform)
		{
			Collider2D map = Physics2D.OverlapCircle(child.position,1,_mask);

    		if(map == null)
			Instantiate(_maps[Random.Range(0,_maps.Length)], child.position, Quaternion.identity);
		}
    }

	public void GenerateMap(Transform mapEntered)
	{
		foreach (Transform child in mapEntered)
			{
				Collider2D map = Physics2D.OverlapCircle(child.position,1,_mask);

				if(map == null)
				Instantiate(_maps[Random.Range(0,_maps.Length)], child.position, Quaternion.identity);
			}
	}

    void Update()
    {
        
    }

	#endregion
}
