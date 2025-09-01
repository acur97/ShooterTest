using UnityEngine;

public class ShootController : MonoBehaviour
{
    [Header("Hitscan")]
    [SerializeField] private float hitScanRange = 100f;
    [SerializeField] private Transform root;
    [SerializeField] private LayerMask layerMask;

    private bool hit = false;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(root.position, root.position + root.forward * hitScanRange);
    }

    private void OnEnable()
    {
        PlayerInputActions.OnFireInput += OnFire;
    }

    private void OnFire()
    {
        hit = Physics.Raycast(root.position, root.forward, out RaycastHit hitInfo, hitScanRange, layerMask);

        if (hit)
        {
            Debug.Log($"{hitInfo.point} - {hitInfo.transform.name}");
        }
    }

    private void OnDisable()
    {
        PlayerInputActions.OnFireInput -= OnFire;
    }
}