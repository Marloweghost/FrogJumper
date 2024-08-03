using UnityEngine;

public abstract class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [Header("General settings")]
    [SerializeField] protected GameObject prefab;
    [SerializeField] protected int prewarmCount;
    [SerializeField] protected Transform spawnPoint;
    [SerializeField] protected Transform container;

    protected EventBus eventBus;

    private bool isEnabled;
    protected bool IsEnabled
    {
        get { return isEnabled; }
        set 
        { 
            isEnabled = value;
            if (isEnabled == true)
            {
                OnSpawnerEnabled();
            }
            else
            {
                OnSpawnerDisabled();
            }
        }
    }

    private CustomPool<T> pool;

    public virtual T Spawn()
    {
        return pool.Get();
    }

    public virtual void Despawn(T _obj)
    {
        pool.Release(_obj);
    }

    protected virtual void OnSpawnerEnabled()
    {

    }
    protected virtual void OnSpawnerDisabled()
    {

    }

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

    protected virtual void Start()
    {
        eventBus = ServiceLocator.Instance.Get<EventBus>();
        eventBus.Subscribe<SetAllSpawnersStateSignal>(SetSpawnerState);
    }

    private void SetSpawnerState(SetAllSpawnersStateSignal _signal)
    {
        IsEnabled = _signal.isEnabled;
    }
}
