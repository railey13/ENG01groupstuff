using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImperfectIceCube : MonoBehaviour
{
    [SerializeField] private GameObjectPool ImperfectIcePool;

    private bool condition;

    public const string CONDITION = "CONDITION";

    // Start is called before the first frame update
    void Start() {
        this.ImperfectIcePool.Initialize();
        EventBroadcaster.Instance.AddObserver(EventNames.PoolSample.SPAWN_IMPERFECT_ICE, this.RequestPoolable);
    }
    private void RequestPoolable(Parameters param) {
        this.condition = param.GetBoolExtra(CONDITION, false);

        if(this.condition) {
            Debug.Log("SUCCESS");
            EventBroadcaster.Instance.PostEvent(EventNames.RootsFear.ON_ICE_SUCCESS);
            
        }
        else {
            Debug.Log("FAIL");
            EventBroadcaster.Instance.PostEvent(EventNames.RootsFear.ON_ICE_FAIL);
        }
    }

}
