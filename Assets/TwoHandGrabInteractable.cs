using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TwoHandGrabInteractable : XRGrabInteractable
{
    //public XRSimpleInteractable secondHandGrabPoint;
    private XRBaseInteractor secondInteractor;

    // Start is called before the first frame update
    void Start()
    {
        // secondHandGrabPoint.onSelectEntered.AddListener(OnSecondHandGrab);
        // secondHandGrabPoint.onSelectExited.AddListener(OnSecondHandRelease);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        if(secondInteractor&& selectingInteractor)
        {
            // compute the rotation
        }
        base.ProcessInteractable(updatePhase);
    }

    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        
        Debug.Log("First hand grab");
        base.OnSelectEntered(interactor);
    }

    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        Debug.Log("First hand grab");
        base.OnSelectExited(interactor);
    }

    public void OnSecondHandGrab(XRBaseInteractor interactor)
    {
        Debug.Log("Second hand grab");
        secondInteractor = interactor;
    }

    public void OnSecondHandRelease(XRBaseInteractor interactor)
    {
        Debug.Log("Second hand release");
        secondInteractor = null ;
    }

    public override bool IsSelectableBy(XRBaseInteractor interactor)
    {
        bool isAlreadyGrabbed = selectingInteractor && !interactor.Equals(selectingInteractor);
        return base.IsSelectableBy(interactor) && !isAlreadyGrabbed;
    }
}
