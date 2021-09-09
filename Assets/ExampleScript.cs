using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    public Transform target;


    void Update () 
    {
        // Vector3 relativePos = (target.position + new Vector3(0, 1.5f, 0)) - transform.position;
        // Quaternion rotation = Quaternion.LookRotation(relativePos);

        // Quaternion current = transform.localRotation;
        // transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime);
        // transform.Translate(0, 0, 3 * Time.deltaTime);

        // Vector3 relativePos = target.position - transform.position;

        // // the second argument, upwards, defaults to Vector3.up
        // Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        // transform.rotation = rotation;

        float angle = Quaternion.Angle(transform.rotation, target.rotation);
        Debug.Log("Angle " + angle);
    }
}
