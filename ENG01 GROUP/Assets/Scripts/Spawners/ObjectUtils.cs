using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectUtils
{
    public static GameObject SpawnDefault(GameObject toSpawn, Transform parentTransform, Vector3 localPos)
    {
        GameObject myObj = GameObject.Instantiate(toSpawn, parentTransform);
        myObj.SetActive(true);
        myObj.transform.localPosition = localPos;
        return myObj;
    }
}
