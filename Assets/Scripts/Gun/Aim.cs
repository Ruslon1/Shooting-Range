using UnityEngine;

public class Aim : MonoBehaviour
{
    private RectTransform _rectTransform;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        FollowMouse();
    }

    private void FollowMouse()
    {
        _rectTransform.position = Input.mousePosition;
    }
}