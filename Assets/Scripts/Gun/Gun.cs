using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(GunShooter))]
public class Gun : MonoBehaviour, IGun
{
    [Range(0, 500)] [SerializeField] private int _amountOfBullets;
    [SerializeField] private float _timeBetweenShoot;

    public event Action Shot;

    private float _remainingTime;
    private bool _canShoot = true;
    private GunShooter _shooter;

    private void Start()
    {
        _shooter = GetComponent<GunShooter>();
        _remainingTime = _timeBetweenShoot;
    }

    private void OnEnable()
    {
        Shot += OnShot;
    }
    
    private void OnDisable()
    {
        Shot -= OnShot;
    }

    public void TryShoot(Ray shootRay)
    {
        if (_amountOfBullets > 0 && _canShoot)
        {
            Debug.DrawRay(transform.position, shootRay.direction*10, Color.red, 0.5f);
            _shooter.Shoot(shootRay);
            StartCoroutine(nameof(CalculateTimeForShoot));
            Shot?.Invoke();
        }
    }

    private IEnumerator CalculateTimeForShoot()
    {
        _canShoot = false;
        while (_remainingTime > 0)
        {
            _remainingTime -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        _canShoot = true;
        _remainingTime = _timeBetweenShoot;
    }
    private void OnShot()
    {
    }
}