using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class IceCubePoolable : APoolable {
    [SerializeField] private Rigidbody icecubeRB;

    private Vector3 originPos;

    private bool release = false;

    private int ValueChance;
    private int IceCubeValue;

    private List<int> listPerfectSquares = new List<int>();
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

        this.IceCubeValueRandomizer();

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

    private void IceCubeValueRandomizer() {
        for (int i = 0; i < 20; i++) {
            this.listPerfectSquares.Add((int)Math.Pow(i + 1, 2));
            Debug.Log("Added");
        }

        this.ValueChance = UnityEngine.Random.Range(1, 5);

        if(this.ValueChance == 1) {
            int i = UnityEngine.Random.Range(0, this.listPerfectSquares.Count);
            Debug.Log(this.listPerfectSquares.Count);
            this.IceCubeValue = this.listPerfectSquares[i];
        }
        else {
            this.IceCubeValue = UnityEngine.Random.Range(1, 400);
        }
    }
}
