using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using VR.Toolkit;

public class CustomXRDirectInteractor : XRDirectInteractor
{
    [SerializeField] private Animator _animator = null;

    public Animator GetAnimator {
        get { return _animator; }
    }

    public void ForceDeselect()
    {
        interactionManager.SelectExit(this, selectTarget);
    } 

    public void ForceDeselectAndDestroy()
    {
        GameObject target = selectTarget.gameObject;
        interactionManager.SelectExit(this, selectTarget);
        Destroy(target);
    } 


}
