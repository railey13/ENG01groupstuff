using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCubeManager : MonoBehaviour
{
    [SerializeField] private GameObjectPool iceCubePool;

    void Start()
    {
        this.iceCubePool.Initialize();
        EventBroadcaster.Instance.AddObserver(EventNames.PoolSample.ON_REQUEST_POOL_PUSHED, this.RequestPoolable);
    }

    private void RequestPoolable() {
        if (this.iceCubePool.HasObjectAvailable(1)) {
            this.iceCubePool.RequestPoolable();
        }
    }

}
