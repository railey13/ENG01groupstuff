using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestHandler : MonoBehaviour
{
    [SerializeField] private GameObject PersonReference;
    [SerializeField] private GameObject EntranceReference;
    [SerializeField] private GameObject TargetReference;

    private Vector3 spawnLocation;
    private Vector3 BarLocation;
    private bool isEntering = false;

    // Start is called before the first frame update
    void Start()
    {
        //setting up the location
        this.spawnLocation = EntranceReference.transform.position;
        this.BarLocation = TargetReference.transform.position;

        //add observer
    }

    // Update is called once per frame
    void Update()
    {
        if (isEntering)
        {
            PersonReference.transform.position = Vector3.MoveTowards(PersonReference.transform.position,
                BarLocation, 
                100 * Time.deltaTime);
        }
    }


    private void PersonEnter()
    {
        PersonReference.transform.position = this.spawnLocation;
    }
}
