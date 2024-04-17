using UnityEngine;

public class ShootController : MonoBehaviour
{
    private void OnEnable()
    {
        PlayerInputActions.OnFireInput += OnFire;
    }

    private void OnFire(bool isPressed)
    {
        Debug.LogWarning("OnFire: " + isPressed);
    }

    private void OnDisable()
    {
        PlayerInputActions.OnFireInput -= OnFire;
    }
}