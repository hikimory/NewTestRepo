using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractUIState : State
{
    private readonly XRController _interactorRay;
    private readonly XRController _teleportRay;

    // Start is called before the first frame update
    public InteractUIState(XRController interactRay, XRController teleportRay)
    {
        _interactorRay = interactRay;
        _teleportRay = teleportRay;
        AddTransition(typeof(IdleState));
    }
    public override void Enter()
    {
        base.Enter();
        _interactorRay.gameObject.SetActive(true);
        _teleportRay.gameObject.SetActive(false);
    }
}
