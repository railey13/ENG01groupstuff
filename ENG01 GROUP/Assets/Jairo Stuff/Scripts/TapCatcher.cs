using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapCatcher : MonoBehaviour
{
    //ITS A SINGLETON
    public static TapCatcher instance { get; private set; }


    Vector2 tap = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tap = Input.mousePosition;
        Debug.Log(tap);
    }
}
