using System;
using UnityEngine;

public class GunEffect : MonoBehaviour
{
    private IGun _gun;

    private void Awake()
    {
        _gun = GetComponent<Gun>();
    }

    private void OnEnable()
    {
        _gun.Shot += OnShot;
    }

    private void OnDisable()
    {
        _gun.Shot -= OnShot;
    }

    private void OnShot()
    {
        Debug.Log("Effect");
    }
}