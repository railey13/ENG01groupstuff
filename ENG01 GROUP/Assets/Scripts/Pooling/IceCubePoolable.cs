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
    private void Start() {

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

    public void CheckValue(string sName) {
        Parameters param = new Parameters();

        if(sName == "Knife" && Mathf.Sqrt(this.IceCubeNum) % 1 == 0) {
            param.PutExtra(PerfectIceCubes.CONDITION, true);
            EventBroadcaster.Instance.PostEvent(EventNames.PoolSample.SPAWN_PERFECT_ICE, param);
        }
        else if(sName == "Knife" && Mathf.Sqrt(this.IceCubeNum) % 1 != 0) {
            param.PutExtra(ImperfectIceCube.CONDITION, false);
            EventBroadcaster.Instance.PostEvent(EventNames.PoolSample.SPAWN_IMPERFECT_ICE, param);
        }
        else if(sName == "Hammer" && Mathf.Sqrt(this.IceCubeNum) % 1 == 0) {
            param.PutExtra(ImperfectIceCube.CONDITION, false);
            EventBroadcaster.Instance.PostEvent(EventNames.PoolSample.SPAWN_IMPERFECT_ICE, param);
        }
        else if(sName == "Hammer" && Mathf.Sqrt(this.IceCubeNum) % 1 != 0) {
            param.PutExtra(ImperfectIceCube.CONDITION, true);
            EventBroadcaster.Instance.PostEvent(EventNames.PoolSample.SPAWN_IMPERFECT_ICE, param);
        }

        this.ReleasePoolable();
    }

    public override void Initialize() {

    }

    public override void OnActivate() {

        for (int i = 1; i <= 20; i++) {
            this.listPerfectSquares.Add((int)Math.Pow(i, 2));
        }

        this.icecubeRB.transform.rotation = Quaternion.identity;
        this.transform.localPosition = this.originPos;

        Vector3 force = new Vector3(0, 20, 0);
        this.icecubeRB.AddForce(force);

        this.IceCubeValueRandomizer();

        GameObject _canvas = this.GetComponentInChildren<Canvas>().gameObject;

        if (_canvas != null) {
            _canvas.GetComponentInChildren<TextMeshProUGUI>().text = this.IceCubeValue.ToString();
        }
    }

    public override void Release() {
        this.icecubeRB.velocity = Vector3.zero;
    }

    private void IceCubeValueRandomizer() {
        this.ValueChance = UnityEngine.Random.Range(1, 5);

        if (this.ValueChance == 1) {
            this.IceCubeValue = this.listPerfectSquares[UnityEngine.Random.Range(0, this.listPerfectSquares.Count)];
        }
        else {
            this.IceCubeValue = UnityEngine.Random.Range(1, 400);
        }
    }
}
