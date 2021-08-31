using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class CustomXRDirectInteractor : XRDirectInteractor
{
    public void ForceDeselect()
    {
        Debug.Log("Call Force");
        Debug.Log(selectTarget.name + " RELEASE");
        base.OnSelectExiting(selectTarget);
        base.OnSelectExited(selectTarget);
    } 
}
