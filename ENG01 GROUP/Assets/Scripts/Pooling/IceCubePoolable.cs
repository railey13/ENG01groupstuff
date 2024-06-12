using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IceCubePoolable : APoolable {
    [SerializeField] private Rigidbody icecubeRB;

    private Vector3 originPos;
    private bool release = false;

    private int IceCubeValue;
    public int IceCubeNum {
        get { return this.IceCubeValue; }
    }

    private void Awake() {
        this.originPos = this.transform.position;

        EventBroadcaster.Instance.AddObserver(EventNames.PoolSample.ON_RELEASE_POOL_PUSHED, this.ReleasePoolable);
    }

    private void ReleasePoolable() {
        this.release = true;
    }

    private void Update() {
        if (this.release) {
            this.poolRef.ReleasePoolable(this);
            release = false;
        }
    }

    public override void Initialize() {

    }

    public override void OnActivate() {
        this.icecubeRB.transform.rotation = Quaternion.identity;
        this.transform.localPosition = this.originPos;

        this.IceCubeValue = Random.Range(1, 400);

        GameObject _canvas = this.GetComponentInChildren<Canvas>().gameObject;

        if (_canvas != null) {
            _canvas.GetComponentInChildren<TextMeshProUGUI>().text = this.IceCubeValue.ToString();
        }
    }

    public override void Release() {
        this.icecubeRB.velocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other) {
        BoxCollider plane = other.GetComponent<BoxCollider>();
        if(plane != null) {
            this.poolRef.ReleasePoolable(this);
        }
    }
}
