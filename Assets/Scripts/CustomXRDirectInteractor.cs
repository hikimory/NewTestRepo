using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class CustomXRDirectInteractor : XRDirectInteractor
{

    [SerializeField] private Animator _animator = null;

    public Animator GetAnimator {
        get { return _animator; }
    }

    public void ForceDeselect()
    {
        Debug.Log("Call Force");
        Debug.Log(selectTarget.name + " RELEASE");
        base.OnSelectExiting(selectTarget);
        base.OnSelectExited(selectTarget);
    } 


}
