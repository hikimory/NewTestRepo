using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractUIState : State
{
    private readonly InteractorController _interactorRay;
    private readonly InteractorController _teleportRay;

    private bool _active = false;
    public bool IsActive {get; private set;} = false;

    // Start is called before the first frame update
    public InteractUIState(InteractorController interactRay, InteractorController teleportRay)
    {
        _interactorRay = interactRay;
        _teleportRay = teleportRay;
        AddTransition(typeof(IdleState));
    }

    public override void Update() 
    {
        if(_interactorRay.m_XRController.inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out _active))
             IsActive = _active;
    }

    public override void Enter()
    {
        base.Enter();
        _interactorRay.Show();
        _teleportRay.Hide();
    }
}
