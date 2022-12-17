using System;
using UnityEngine;

public class GunInput : MonoBehaviour
{
    private Gun _gun;
    private Camera _camera;

    private void Start()
    {
        _gun = GetComponent<Gun>();
        _camera = Camera.main;
    }

    private void Update()
    {
        DetectShootInput();
        FollowMouse();
    }

    private void DetectShootInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _gun.TryShoot(MousePositionToRay(Input.mousePosition));
        }
    }

    private void FollowMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -10;
        Vector3 targetPosition = _camera.ScreenToWorldPoint(mousePosition);
        transform.LookAt(targetPosition);
    }

    private Ray MousePositionToRay(Vector3 mousePosition)
    {
        mousePosition.z = _camera.nearClipPlane;
        Ray ray = _camera.ScreenPointToRay(mousePosition);
        return ray;
    }
}