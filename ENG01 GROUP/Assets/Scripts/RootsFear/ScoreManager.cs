using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int _attempts;

    // Start is called before the first frame update
    void Start()
    {
        this._attempts = 3;

        //add observer
        EventBroadcaster.Instance.AddObserver(EventNames.RootsFear.ON_CUSTOMER_MAD, this.GetAnnoyed);
        EventBroadcaster.Instance.AddObserver(EventNames.RootsFear.ON_ICE_SUCCESS, this.GetSatisfied);
    }

    // Update is called once per frame
    void Update()
    {
        if (this._attempts <= 0) SceneManager.LoadScene("GameOver");
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.RootsFear.ON_ICE_FAIL);
        EventBroadcaster.Instance.RemoveObserver(EventNames.RootsFear.ON_ICE_SUCCESS);
    }

    private void GetAnnoyed()
    {
        this._attempts--;
    }

    private void GetSatisfied()
    {
        if (this._attempts > 0 && this._attempts < 3)
        {
            this._attempts++;
        }
    }
}
