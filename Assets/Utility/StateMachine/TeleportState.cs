using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportState : State
{
    private readonly InteractorController _interactorRay;
    private readonly InteractorController _teleportRay;
    private readonly StateMachine _machine;
    
    public TeleportState(StateMachine machine, InteractorController interactRay, InteractorController teleportRay)
    {
        _machine = machine;
        _interactorRay = interactRay;
        _teleportRay = teleportRay;
        AddTransition(typeof(IdleState));
    }

    public override void Enter()
    {
        base.Enter();
       _teleportRay.Show();
       _interactorRay.Hide();
    }
    public override void Exit()
    {
        base.Exit();
        //_interactorRay.Hide();
        _teleportRay.Hide();
    }
    public override void Update()
    {
        base.Update();
        if(_teleportRay.m_XRController.inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out var activated))
        {
            if(activated == false)
            {
                if(_machine.CanTransact(TypeState.Idle))
                {
                    Debug.Log("Transact(TypeState.Idle)");
                    _machine.Transact(TypeState.Idle);
                }
            }
        }
    }
}

//_allow select hover  false
//visual line false.