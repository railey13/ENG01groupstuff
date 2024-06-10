using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolableButton : MonoBehaviour
{
    public void OnRequestPoolButtonPushed() {
        EventBroadcaster.Instance.PostEvent(EventNames.PoolSample.ON_REQUEST_POOL_PUSHED);
    }

    public void OnReleasePoolButtonPushed() {
        EventBroadcaster.Instance.PostEvent(EventNames.PoolSample.ON_RELEASE_POOL_PUSHED);
    }
}
