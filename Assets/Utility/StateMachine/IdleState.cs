using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class IdleState : State
{
    private readonly InteractorController _interactorRay;
    private readonly InteractorController _teleportRay;

    public IdleState(InteractorController interactRay, InteractorController teleportRay)
    {
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
    }
}
