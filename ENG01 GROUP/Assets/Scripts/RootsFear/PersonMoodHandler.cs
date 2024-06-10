using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonMoodHandler : MonoBehaviour
{
    [SerializeField] private int patience = 3;

    [SerializeField] private Material HappyFace;
    [SerializeField] private Material SmileFace;
    [SerializeField] private Material MehFace;
    [SerializeField] private Material MadFace;
    [SerializeField] private Material AnnoyedFace;

    [SerializeField] private GameObject Face;

    private Renderer faceRenderer;
    private bool isLeaving = false;

    // Start is called before the first frame update
    void Start()
    {
        //add observer
        EventBroadcaster.Instance.AddObserver(EventNames.RootsFear.ON_ICE_FAIL, this.GetAnnoyed);
        EventBroadcaster.Instance.AddObserver(EventNames.RootsFear.ON_ICE_SUCCESS, this.GetSatisfied);

        //set default emotion
        this.faceRenderer = Face.GetComponent<Renderer>();
        faceRenderer.material = SmileFace;
    }

    // Update is called once per frame
    void Update()
    {
        if (isLeaving)
        {

        }
    }
    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.RootsFear.ON_ICE_FAIL);
        EventBroadcaster.Instance.RemoveObserver(EventNames.RootsFear.ON_ICE_SUCCESS);
    }

    private void GetAnnoyed()
    {
        switch (this.patience)
        {
            case 3:
                faceRenderer.material = MehFace;
                break;
            case 2:
                faceRenderer.material = AnnoyedFace;
                break;
            case 1:
                faceRenderer.material = MadFace;
                break;
        }

        if (this.patience > 0)
        this.patience--;
    }

    private void GetSatisfied()
    {
        faceRenderer.material = HappyFace;
    }
}
