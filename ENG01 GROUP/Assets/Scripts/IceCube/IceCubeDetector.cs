using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCubeDetector : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        IceCubePoolable iceCube = other.GetComponent<IceCubePoolable>();
        Debug.Log("Hi");
        if (iceCube != null) {
            iceCube.CheckValue();
        }
    }
}
