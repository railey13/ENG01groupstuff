using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCubeDetector : MonoBehaviour
{
    [SerializeField] private string sName;
    void OnTriggerEnter(Collider other) {

        IceCubePoolable iceCube = other.GetComponent<IceCubePoolable>();

        if (iceCube != null) {
            iceCube.CheckValue(sName);
        }
    }
}
