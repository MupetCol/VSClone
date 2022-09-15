using UnityEngine;

public class CollectableBase : MonoBehaviour
{
	private bool _collected = false;
	private Transform _collector;

	public void CollectionEnabled(Transform collector)
	{
		_collector = collector;
		_collected = true;
	}

	private void Update()
	{
		if (_collected)
			transform.Translate(
				(_collector.position - transform.position)
				.normalized * Time.deltaTime * 2);
	}
}
