using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PersonMoodHandler : MonoBehaviour
{
    //positions to be noted
    [SerializeField] private GameObject exitTarget;
    [SerializeField] private GameObject EntranceReference;
    [SerializeField] private GameObject BarReference;

    //FACES
    [SerializeField] private Material HappyFace;
    [SerializeField] private Material SmileFace;
    [SerializeField] private Material MehFace;
    [SerializeField] private Material MadFace;
    [SerializeField] private Material AnnoyedFace;

    [SerializeField] private GameObject Face;

    //AUDIO
    [SerializeField] private AudioSource HappySound;
    [SerializeField] private AudioSource AnnoyedSound;

    private Renderer faceRenderer;

    private bool isLeaving = false;
    private bool isEntering = false;

    private int patience = 6;

    private Vector3 exitPos = Vector3.zero;
    private Vector3 entrancePos = Vector3.zero;
    private Vector3 barPos = Vector3.zero;

    private float speed = 70;

    // Start is called before the first frame update
    void Start()
    {
        //add observer
        EventBroadcaster.Instance.AddObserver(EventNames.RootsFear.ON_ICE_FAIL, this.GetAnnoyed);
        EventBroadcaster.Instance.AddObserver(EventNames.RootsFear.ON_ICE_SUCCESS, this.GetSatisfied);

        //set default emotion
        this.faceRenderer = Face.GetComponent<Renderer>();
        faceRenderer.material = SmileFace;

        //setting up positions
        this.exitPos = exitTarget.transform.position;
        this.entrancePos = EntranceReference.transform.position;
        this.barPos = BarReference.transform.position;

        //hiding
        this.BarReference.GetComponent<Renderer>().enabled = false;

        this.ChangeColor();
    }

    // Update is called once per frame
    void Update()
    {
        if (isLeaving)
        {
            transform.position = Vector3.MoveTowards(transform.position, exitPos, this.speed * Time.deltaTime);
        }

        if (isEntering)
        {
            transform.position = Vector3.MoveTowards(transform.position, barPos, this.speed * Time.deltaTime);
            if (transform.position == this.barPos) isEntering = false;
        }
    }
    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.RootsFear.ON_ICE_FAIL);
        EventBroadcaster.Instance.RemoveObserver(EventNames.RootsFear.ON_ICE_SUCCESS);
    }

    private void GetAnnoyed()
    {
        this.AnnoyedSound.Play();
        switch (this.patience)
        {
            case 6:
                faceRenderer.material = MehFace;
                break;
            case 4:
                faceRenderer.material = AnnoyedFace;
                break;
            case 2:
                faceRenderer.material = MadFace;
                break;
        }

        if (this.patience > 0)
            this.patience--;
        
        if (this.patience <= 0)
        {
            EventBroadcaster.Instance.PostEvent(EventNames.RootsFear.ON_CUSTOMER_MAD);
            this.isLeaving = true;
            this.patience = 6;
        }
    }

    private void GetSatisfied()
    {
        this.HappySound.Play();
        faceRenderer.material = HappyFace;
        this.isLeaving = true;
        this.patience = 6;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == this.exitTarget)
        {
            this.isLeaving = false;
            this.transform.position = this.entrancePos;
            this.isEntering = true;
            faceRenderer.material = SmileFace;
            this.ChangeColor();
        }
    }

    private void ChangeColor()
    {
        gameObject.GetComponent<Renderer>().material.color = new Color(
                Random.Range(0.0f, 1.0f),
                Random.Range(0.0f, 1.0f),
                Random.Range(0.0f, 1.0f)
                );
    }
}
