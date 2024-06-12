using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCube : MonoBehaviour
{
    [SerializeField] private Collider plane;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if (other == this.plane) {
            IceCubePoolable ice = GetComponent<IceCubePoolable>();
            
            if(Mathf.Sqrt(ice.IceCubeNum) == 0) {
                EventBroadcaster.Instance.PostEvent(EventNames.PoolSample.ON_RELEASE_POOL_PUSHED);
            }
        }
    }
}
