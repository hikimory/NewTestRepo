using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ReleaseGrabInteractable : XRGrabInteractable
{

    [SerializeField] private float _distance = 0.38f;
    Rigidbody rb_handler = null;

    private void Start() {
        rb_handler = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        if(selectingInteractor != null)
        {
            Debug.Log("Distance" + Vector3.Distance(selectingInteractor.transform.position, transform.position));
            if(Vector3.Distance(selectingInteractor.transform.position, transform.position) > _distance)
            {
                ReleaseInteractor(this.selectingInteractor);
            }
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
        
        rb_handler.velocity = Vector3.zero;
        rb_handler.angularVelocity = Vector3.zero;
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
}
