using UnityEngine;

public abstract class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [Header("General settings")]
    [SerializeField] protected GameObject prefab;
    [SerializeField] protected int prewarmCount;
    [SerializeField] protected Transform spawnPoint;
    [SerializeField] protected Transform container;

    private CustomPool<T> pool;

    private void Awake()
    {
        if (prefab == null)
        {
            throw new MissingReferenceException("Prefab reference is missing!");
        }

        if (prefab.TryGetComponent(out T _component))
        {
            pool = new CustomPool<T>(_component, prewarmCount, container);
        }
        else
        {
            throw new MissingComponentException($"Component of type {_component.GetType()} inside the prefab is missing!");
        }
    }

    public virtual T Spawn()
    {
        return pool.Get();
    }

    public virtual void Despawn(T _obj)
    {
        pool.Release(_obj);
    }
}
