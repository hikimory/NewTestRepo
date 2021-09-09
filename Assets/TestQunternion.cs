using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestQunternion : MonoBehaviour
{
    float x;
    void Update () 
    {
        x += Time.deltaTime * 10;
        Quaternion rotation = Quaternion.Euler(x,0,0);
        print(rotation.eulerAngles);
        transform.rotation = rotation;
    }
}
