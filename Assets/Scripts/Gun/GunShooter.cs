using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GunShooter : MonoBehaviour, IShootable
{
    public void Shoot(Ray shootRay)
    {
        Physics.Raycast(shootRay, out RaycastHit hit, 100);
        if(hit.collider.TryGetComponent(out ITarget target))
            target.Close();
    }
}