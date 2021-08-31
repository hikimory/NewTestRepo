using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorGrabable : XRGrabInteractable
{
    public Transform handler;
    LayerMask mask;

    Rigidbody rb_handler = null;

    private void Start() {
        rb_handler = handler.GetComponent<Rigidbody>();
    }

    public void ReleaseInteractor(XRBaseInteractor interactor)
    {
        if(interactor is CustomXRDirectInteractor intr)
        {
            OnSelectExiting(interactor);
            OnSelectExited(interactor);
            intr.ForceDeselect();
        }
    }

    void Update()
    {
        if(Vector3.Distance(handler.position, transform.position) > 0.15f)
        {
            ReleaseInteractor(this.selectingInteractor);
        }
    }

    protected override void OnSelectExiting(XRBaseInteractor interactor)
    {
        Debug.Log(interactor.name + " RELEASE OnSelectExiting");
        base.OnSelectExiting(interactor);
    }

    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        Debug.Log(interactor.name + " RELEASE OnSelectExited");
        base.OnSelectExited(interactor);

        transform.position = handler.position;
        transform.rotation = handler.rotation;

        rb_handler.velocity = Vector3.zero;
        rb_handler.angularVelocity = Vector3.zero;
    }
}
