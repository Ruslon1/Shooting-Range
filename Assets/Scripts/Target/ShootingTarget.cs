using UnityEngine;

public class ShootingTarget : MonoBehaviour, ITarget
{
    [SerializeField] private Quaternion _targetRotation;
    [SerializeField] private Quaternion _defaultRotation;
    
    public void Show()
    {
        transform.rotation = _targetRotation;
    }

    public void Close()
    {
        transform.rotation = _defaultRotation;
    }
}