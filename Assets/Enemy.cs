using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	public float _timeBetweenHit;
	public float _damagePoints = 5f;
	public float _trackingSpeed = 1f;

	#endregion

	#region PRIVATE_VARIABLES

	private GameObject _player;
	private bool _canDealDamage = true;

	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

    void Start()
    {
		_player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    void Update()
    {
		// Create an offset so it doesnt follow the player directly, updates the direction every .2s might feel more
		// comfortable to the player
		transform.Translate((_player.transform.position - transform.position).normalized  * Time.deltaTime * _trackingSpeed);
	}

	//private void OnCollisionEnter2D(Collision2D collision)
	//{
	//	Debug.Log(collision.ToString());
	//	if (collision.gameObject.tag == "Player" && _canDealDamage)
	//	{
	//		collision.gameObject.GetComponent<PlayerHandler>()._character.currHealth -= (_damagePoints * Time.deltaTime);
	//	}
	//}


	private void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player" && _canDealDamage)
		{
			StartCoroutine(DealDamage(collision));
		}
	}



	#endregion

	public IEnumerator DealDamage(Collision2D coll)
	{
		_canDealDamage = false;
		coll.gameObject.GetComponent<PlayerHandler>()._character.currHealth -= _damagePoints;
		yield return new WaitForSeconds(_timeBetweenHit);
		_canDealDamage = true;
	}
}
