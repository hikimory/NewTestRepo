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
    // [SerializeField] private InputDeviceCharacteristics typeDevice = InputDeviceCharacteristics.None;
    // [SerializeField] private InputHelpers.Button m_teleportButton = InputHelpers.Button.None;
    
    // private InputDevice _controller;

    private IState _currentState = null;
    private Dictionary<TypeState, IState> _states;

    public bool isActiveOnUI = false;
    public bool interactWithUI = false;

    // protected void OnEnable()
    // {
    //     InputDevices.deviceConnected += RegisterDevices;
    // }

    // protected void OnDisable()
    // {
    //     InputDevices.deviceConnected -= RegisterDevices;
    // }

    // void RegisterDevices(InputDevice connectedDevice)
    // {
    //     if (connectedDevice.isValid)
    //     {
    //         if ((connectedDevice.characteristics & typeDevice) != 0)
    //         {
    //             _controller = connectedDevice;
    //         }
    //     }
    // }

    private void Awake()
    {
        _states = new Dictionary<TypeState, IState>();
        _states.Add(TypeState.Idle, new IdleState(_interactorRay, _teleportRay));
        _states.Add(TypeState.Interact, new InteractUIState(_interactorRay, _teleportRay));
        _states.Add(TypeState.Teleport, new TeleportState(_interactorRay, _teleportRay));
    }

    private void Start()
    {
        _currentState = _states[TypeState.Idle];
        _currentState.Enter();
    }

    public void Update()
    {
        if (_currentState == null) return;
        _currentState.Update();
        Debug.Log(_currentState.GetType());

        // if (_controller.isValid)
        // {
        //     var activated = false;
        //     if (_controller.IsPressed(m_teleportButton, out var value, 0.1f))
        //     {
        //         activated |= value;
        //         if(activated && CanTransact(TypeState.Teleport) && isActiveOnUI == false)
        //         {
        //             Transact(TypeState.Teleport);
        //         }
                
        //         if(interactWithUI)
        //         {
        //             Debug.Log("Active on UI");
        //             isActiveOnUI = true;
        //         }
        //     }
        //     else if(isActiveOnUI && interactWithUI == false)
        //     {
        //         isActiveOnUI = false;
        //     }
        // }
    }

    public void EnterInteractState()
    {
        interactWithUI = true;
        if (CanTransact(TypeState.Interact))
        {
            Transact(TypeState.Interact);
        }
    }

    public void ExitInteractState()
    {
        interactWithUI = false;
        if (CanTransact(TypeState.Idle))
        {
            Transact(TypeState.Idle);
        }
    }

    public void ActiveOnUI(SelectEnterEventArgs args)
    {
        isActiveOnUI = true;
    }

    public void InActiveOnUI(SelectExitEventArgs args)
    {
        isActiveOnUI = false;
    }

    public bool CanTransact(TypeState state)
    {
        return _currentState.CanTransact(_states[state]);
    }

    public void Transact(TypeState state)
    {
        _currentState.Exit();
        _currentState = _states[state];
        _currentState.Enter();
    }

    public bool CheckCurrentState(TypeState state)
    {
        return _currentState == _states[state];
    }
}

public enum TypeState : uint
{
    Idle = 0,
    Teleport = 1,
    Interact = 2,
}
