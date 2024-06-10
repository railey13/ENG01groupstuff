using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmotionInator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnAnnoyClicked()
    {
        EventBroadcaster.Instance.PostEvent(EventNames.RootsFear.ON_ICE_FAIL);
    }

    public void OnHappyClicked()
    {
        EventBroadcaster.Instance.PostEvent(EventNames.RootsFear.ON_ICE_SUCCESS);
    }
}
