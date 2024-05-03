using Cysharp.Text;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    [Header("Hitscan")]
    [SerializeField] private float hitScanRange = 100f;
    [SerializeField] private Transform root;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(root.position, root.position + root.forward * hitScanRange);
    }

    private void OnEnable()
    {
        PlayerInputActions.OnFireInput += OnFire;
    }

    private void OnFire(bool isPressed)
    {
        Debug.LogWarning(ZString.Concat("OnFire: ", isPressed));
    }

    private void OnDisable()
    {
        PlayerInputActions.OnFireInput -= OnFire;
    }
}