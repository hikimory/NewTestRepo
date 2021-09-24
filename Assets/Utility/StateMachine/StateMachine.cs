using System;
using System.Collections.Generic;
using VR.Toolkit;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private XRController _interactorRay;
    [SerializeField] private XRController _teleportRay;

    private IState _currentState = null;
    private IState _idleState = null;
    private IState _teleportState = null;
    private IState _interactUIState = null;

    public InputHelpers.Button teleportActivationButton;
    public float activationThreshold = 0.1f;

    private void Start()
    {
        _idleState = new IdleState(_interactorRay, _teleportRay);
        _teleportState = new TeleportState(_interactorRay, _teleportRay);
        _interactUIState = new InteractUIState(_interactorRay, _teleportRay);

        _currentState = _idleState;
        _currentState.Enter();
    }

    private void Update()
    {
        if (_currentState == null) return;
        _currentState.Update();

        if(CheckIfActivated(_teleportRay) && _currentState.CanTransact(_teleportState))
        {
            Transact(_teleportState);
        }

        if(CheckIfActivated(_teleportRay) == false && _currentState.CanTransact(_idleState))
        {
            Transact(_idleState);
        }

        if(CheckIfActivated(_interactorRay) && _currentState.CanTransact(_interactUIState))
        {
            Transact(_interactUIState);
        }

        if(CheckIfActivated(_interactorRay) == false && _currentState.CanTransact(_idleState))
        {
            Transact(_idleState);
        }
    }

    public void Transact(IState state)
    {
        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    private bool CheckIfActivated(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, teleportActivationButton, out bool isActivated, activationThreshold);
        return isActivated;
    }
}
