using UnityEngine;

public class InfiniteMapGenerator : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	[SerializeField] private GameObject _startMap;
	[SerializeField] private GameObject[] _maps;

	//All maps must have same resolutions for this to work
	private float _textureUnitSizeX;
	private float _textureUnitSizeY;
	private Transform _cameraTransform;
	private Vector3 _usedCorrectPosition;

	public Vector3 _startingPos = Vector3.zero;

	private Transform _currentMapTransform;
	private bool _canInstantiate = true;

	#endregion

	#region PRIVATE_VARIABLES


	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

	private void Awake() 
	{
		_cameraTransform = Camera.main.transform;
		_currentMapTransform = _startMap.transform;
		_usedCorrectPosition = _currentMapTransform.position;
	}

    void Start()
    {
		SetCurrentMap(_currentMapTransform);
    }

	// false = x, true = y
	void SetCurrentMap(Transform map)
	{
		Sprite _sprite = map.gameObject.GetComponent<SpriteRenderer>().sprite;
		Texture2D _texture = _sprite.texture;
		//Constant values for all maps are expected right now, if maps with different resolutions
		// are going to be implemented this must be changed
		_textureUnitSizeX = _texture.width / _sprite.pixelsPerUnit;
		_textureUnitSizeY = _texture.height / _sprite.pixelsPerUnit;
	}

    private void LateUpdate() 
	{
		//BASE
		// if(Mathf.Abs(_cameraTransform.position.x - _usedCorrectPosition.x) >= _textureUnitSizeX && _canInstantiate)
		// {
		// 	_canInstantiate = false;
		// 	float offsetPositionX = (_cameraTransform.position.x - _currentMapTransform.position.x) % _textureUnitSizeX;
		// 	//_currentMapTransform.position = new Vector3(_cameraTransform.position.x + offsetPositionX, _currentMapTransform.position.y);

		// 	//Multiplied by three due to the 3 times width/height offset
		// 	var instance = Instantiate(_maps[Random.Range(0,_maps.Length)], new Vector3((_cameraTransform.position.x + offsetPositionX)*3,_currentMapTransform.position.y), Quaternion.identity).transform;
		// 	_currentMapTransform = instance.transform;
		// 	SetCurrentMap(_currentMapTransform,false);
		// 	_canInstantiate = true;
		// }

		//Movement right
		if((_cameraTransform.position.x - _currentMapTransform.position.x) >= _textureUnitSizeX && _cameraTransform.position.x > _startingPos.x)
		{
			float offsetPositionX = (_cameraTransform.position.x - _currentMapTransform.position.x) % _textureUnitSizeX;
			//transform.position = new Vector3(transform.position.x, _cameraTransform.position.y + offsetPositionY);

			//Multiplied by three due to the 3 times width/height offset
			var instance = Instantiate(_maps[Random.Range(0,_maps.Length)], new Vector3((_cameraTransform.position.x + offsetPositionX)+(_textureUnitSizeX*2), _currentMapTransform.position.y) , Quaternion.identity).transform;
			_currentMapTransform = instance.transform;
			SetCurrentMap(_currentMapTransform);
			
		}

		//Movement left
		if((_cameraTransform.position.x - _currentMapTransform.position.x) <= -_textureUnitSizeX && _cameraTransform.position.x < _startingPos.x)
		{
			float offsetPositionX = (_cameraTransform.position.x - _currentMapTransform.position.x) % _textureUnitSizeX;
			//transform.position = new Vector3(transform.position.x, _cameraTransform.position.y + offsetPositionY);

			//Multiplied by three due to the 3 times width/height offset
			var instance = Instantiate(_maps[Random.Range(0,_maps.Length)], new Vector3((_cameraTransform.position.x + offsetPositionX)-(_textureUnitSizeX*2), _currentMapTransform.position.y) , Quaternion.identity).transform;
			_currentMapTransform = instance.transform;
			SetCurrentMap(_currentMapTransform);
			
		}

		//Movement Up
		if((_cameraTransform.position.y - _currentMapTransform.position.y) >= _textureUnitSizeY && _cameraTransform.position.y > _startingPos.y)
		{
			float offsetPositionY = (_cameraTransform.position.y - _currentMapTransform.position.y) % _textureUnitSizeY;
			//transform.position = new Vector3(transform.position.x, _cameraTransform.position.y + offsetPositionY);

			//Multiplied by three due to the 3 times width/height offset
			var instance = Instantiate(_maps[Random.Range(0,_maps.Length)], new Vector3(_currentMapTransform.position.x, (_cameraTransform.position.y + offsetPositionY)+(_textureUnitSizeY*2)), Quaternion.identity).transform;
			_currentMapTransform = instance.transform;
			SetCurrentMap(_currentMapTransform);
			
		}

		//Movement Down
		if((_cameraTransform.position.y - _currentMapTransform.position.y) <= -_textureUnitSizeY && _cameraTransform.position.y < _startingPos.y)
		{
			float offsetPositionY = (_cameraTransform.position.y - _currentMapTransform.position.y) % _textureUnitSizeY;
			//transform.position = new Vector3(transform.position.x, _cameraTransform.position.y + offsetPositionY);

			//Multiplied by three due to the 3 times width/height offset
			var instance = Instantiate(_maps[Random.Range(0,_maps.Length)], new Vector3(_currentMapTransform.position.x, (_cameraTransform.position.y + offsetPositionY)-(_textureUnitSizeY*2)), Quaternion.identity).transform;
			_currentMapTransform = instance.transform;
			SetCurrentMap(_currentMapTransform);
			
		}
		Debug.Log(_cameraTransform.position.y - _currentMapTransform.position.y);
	}

	#endregion
}
