using UnityEngine;
using System.Collections;
using DG.Tweening;

public class PeachoneBehavior : WeaponBase
{
    #region PUBLIC_VARIABLES


    #endregion

    #region PRIVATE_VARIABLES

    [SerializeField] private PeachoneProjectile _projectile;
    [SerializeField] private GameObject _bombardingZone;
    private float _timer = 0f;
    public float _rotationSpeed = 100f;
    public bool _onAction = false;
	#endregion

	#region PRIVATE_SERIALIZED_VARIABLES



	#endregion

	#region UNITY_METHODS

	private void OnEnable()
	{
		
	}
	void Start()
    {
        StartCoroutine(PeachoneFlow());
    }

    void Update()
    {
		if (_onAction)
		{
            _bombardingZone.transform.RotateAround(transform.position, new Vector3(0,0,1), _rotationSpeed* Time.deltaTime);
		}
    }

    IEnumerator PeachoneFlow()
    {
        while (true)
        {
            _bombardingZone.SetActive(true);
            _onAction = true;

            _bombardingZone.transform.localScale *= _weaponStats.area * _weaponStats.globalArea.Value;

            _timer = 0;

            while (_timer < duration)
            {
                Vector3 centerOfRadius = transform.GetChild(0).transform.position;
                float radius = .5f * _weaponStats.area * _weaponStats.globalArea.Value;
                Vector3 target = centerOfRadius + (Vector3)(radius * UnityEngine.Random.insideUnitCircle);


                _timer += _weaponStats.projectInverval;

                PeachoneProjectile instance = Instantiate(_projectile, transform.position, Quaternion.identity);
                instance.SetTarget(target);
                yield return new WaitForSeconds(_weaponStats.projectInverval);
            }
            _onAction = false;
            _bombardingZone.SetActive(false);
            yield return new WaitForSeconds(cooldown / _weaponStats.globalSpeed.Value);
        }
    }


    #endregion
}
