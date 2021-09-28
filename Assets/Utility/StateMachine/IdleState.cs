using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class IdleState : State
{
    private readonly InteractorController _interactorRay;
    private readonly InteractorController _teleportRay;
    private readonly StateMachine _machine;

    public IdleState(StateMachine machine, InteractorController interactRay, InteractorController teleportRay)
    {
        _machine = machine;
        _interactorRay = interactRay;
        _teleportRay = teleportRay;
        AddTransition(typeof(TeleportState));
        AddTransition(typeof(InteractUIState));
    }
    public override void Enter()
    {
        base.Enter();
        _teleportRay.Hide();
        _interactorRay.Show();
    }
    public override void Exit()
    {
        base.Exit();
        _teleportRay.Hide();
        _interactorRay.Hide();
    }
    public override void Update()
    {
        base.Update();
        bool _activated;
        if(_interactorRay.m_XRController.inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out _activated))
        {
            if(_activated)
            {
                if(_machine.CanTransact(TypeState.Teleport) && _machine.isActiveOnUI == false)
                    _machine.Transact(TypeState.Teleport);
            }
        }
    }
}
