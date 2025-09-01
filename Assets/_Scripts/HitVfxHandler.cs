using Cysharp.Threading.Tasks;
using UnityEngine;

public class HitVfxHandler : MonoBehaviour
{
    public static HitVfxHandler Instance;

    [SerializeField] private GameObject hitVfxPrefab;
    [SerializeField] private Transform hitVfxParent;
    [SerializeField] private int poolSize = 10;

    private PoolSystem<Transform> pool;
    private PoolSystem pool2;

    private void Awake()
    {
        Instance = this;
    }

    [ContextMenu("Test")]
    private async UniTaskVoid Test()
    {
        //pool = new PoolSystem<Transform>();
        //pool.Create(hitVfxPrefab.transform, poolSize, hitVfxParent).Forget();
        //pool.GetObject();

        pool2 = new PoolSystem();
        await pool2.Create(hitVfxPrefab, poolSize, hitVfxParent);
        pool2.GetObject();
    }

    [ContextMenu("Test2")]
    private void Test2()
    {
        Debug.Log(pool2.GetObject().transform.GetSiblingIndex());
    }
}