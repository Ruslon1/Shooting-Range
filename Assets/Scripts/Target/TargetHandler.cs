using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TargetHandler : MonoBehaviour
{
    [SerializeField] private List<ShootingTarget> _targets;
    [SerializeField] private Gun _gun;

    private void OnEnable() => _gun.Shot += OnShot;

    private void OnDisable() => _gun.Shot -= OnShot;

    private void Start() => ShowSomeTarget();

    private void OnShot() => ShowSomeTarget();

    private void ShowSomeTarget() => _targets[Random.Range(0,_targets.Count)].Show();
}