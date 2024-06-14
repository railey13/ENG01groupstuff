using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCubeManager : MonoBehaviour
{
    [SerializeField] private GameObjectPool iceCubePool;

    void Start()
    {
        this.iceCubePool.Initialize();
        
        this.StartCoroutine(this.TriggerEvery(1));
    }
    private IEnumerator TriggerEvery(float sec) {
        yield return new WaitForSeconds(sec);
        this.RequestPoolable();

        this.StartCoroutine(this.TriggerEvery(4));
    }

    private void RequestPoolable() {
        if (this.iceCubePool.HasObjectAvailable(1)) {
            this.iceCubePool.RequestPoolable();
        }
    }

}
