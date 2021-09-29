using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractUIState : State
{
    private readonly InteractorController _interactorRay;
    private readonly InteractorController _teleportRay;
    private readonly StateMachine _machine;


    // Start is called before the first frame update
    public InteractUIState(StateMachine machine, InteractorController interactRay, InteractorController teleportRay)
    {
        _machine = machine;
        _interactorRay = interactRay;
        _teleportRay = teleportRay;
        AddTransition(typeof(IdleState));
    }

    public override void Update() 
    {
         
        if(_interactorRay.m_XRController.inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out var activated))
             _machine.isInteractOnUI = activated;
    }

    public override void Enter()
    {
        base.Enter();
        _interactorRay.Show();
        _teleportRay.Hide();
    }
}
