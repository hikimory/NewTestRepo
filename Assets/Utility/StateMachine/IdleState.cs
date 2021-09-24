using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class IdleState : State
{
    private readonly XRController _interactorRay;
    private readonly XRController _teleportRay;

    public IdleState(XRController interactRay, XRController teleportRay)
    {
         _interactorRay = interactRay;
        _teleportRay = teleportRay;
        AddTransition(typeof(TeleportState));
        AddTransition(typeof(InteractUIState));
    }
    public override void Enter()
    {
        base.Enter();
        _teleportRay.gameObject.SetActive(false);
        _interactorRay.gameObject.SetActive(true);
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void Update()
    {
        base.Update();
    }
}
