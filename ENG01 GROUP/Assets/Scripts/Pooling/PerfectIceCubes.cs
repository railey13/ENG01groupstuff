using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfectIceCubes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.PoolSample.SPAWN_PERFECT_ICE, this.RequestPoolable);
    }

    private void RequestPoolable() {

    }
}
