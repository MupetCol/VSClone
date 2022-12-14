using UnityEngine;
using UnityEngine.UI;

public class HealthSliderBehavior : MonoBehaviour
{
	#region PUBLIC_VARIABLES

	public FloatReference _health;

	#endregion

	#region PRIVATE_VARIABLES

	private Slider _healthBar;

	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

	void Start()
    {
		_healthBar = GetComponent<Slider>();
    }

    void Update()
    {
		_healthBar.value = _health.Value / Utilities.Instance._maxHealth.Value;
    }

	#endregion
}
