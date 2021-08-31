using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CabinetGrabable : XRGrabInteractable
{
    private XRBaseInteractor _interactor;
    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        base.OnSelectEntered(interactor);

        if (interactor is XRDirectInteractor)
            _interactor = interactor;
    }

    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        base.OnSelectExited(interactor);

        if (interactor is XRDirectInteractor)
            _interactor = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
