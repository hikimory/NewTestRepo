using System;
using System.Collections.Generic;
using VR.Toolkit;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private GameObject _interactor;
    [SerializeField] private GameObject _teleport;
    // [SerializeField] private InputDeviceCharacteristics typeDevice = InputDeviceCharacteristics.None;
    // [SerializeField] private InputHelpers.Button m_teleportButton = InputHelpers.Button.None;
    
    // private InputDevice _controller;

    private IState _currentState = null;
    private Dictionary<TypeState, IState> _states;

    public bool isHoverOnUI = false;
    public bool isInteractOnUI = false;

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
        InteractorController teleportController = new InteractorController();
        teleportController.Attach(_teleport);
        InteractorController interactController = new InteractorController();
        interactController.Attach(_interactor);
        
        _states = new Dictionary<TypeState, IState>();
        _states.Add(TypeState.Idle, new IdleState(this, interactController, teleportController));
        _states.Add(TypeState.Interact, new InteractUIState(this, interactController, teleportController));
        _states.Add(TypeState.Teleport, new TeleportState(this, interactController, teleportController));
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
    }

    public void EnterInteractState()
    {
        if (CanTransact(TypeState.Interact))
        {
            isHoverOnUI = true;
            Debug.Log("TypeState.Interact");
            Transact(TypeState.Interact);
        }
    }

    public void ExitInteractState()
    {
        if (CanTransact(TypeState.Idle))
        {
            isHoverOnUI  = false;
            Transact(TypeState.Idle);
        }
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

public struct InteractorController
{
    public GameObject m_GO;
    public XRController m_XRController;
    public XRInteractorLineVisual m_LineRenderer;
    public XRBaseInteractor m_Interactor;
    
    public void Attach(GameObject gameObject)
    {
        m_GO = gameObject;
        if (m_GO != null)
        {
            m_XRController = m_GO.GetComponent<XRController>();
            m_LineRenderer = m_GO.GetComponent<XRInteractorLineVisual>();
            m_Interactor = m_GO.GetComponent<XRBaseInteractor>();

            Hide();               
        }
    }

    public void Show()
    {
        SetState(true);
    }

    public void Hide()
    {
        SetState(false);
    }

    private void SetState(bool state)
    {
        if (m_LineRenderer)
        {
            m_LineRenderer.enabled = state;
        }
        if (m_XRController)
        {
            m_XRController.enableInputActions = state;
        }
        if (m_Interactor)
        {
            m_Interactor.enabled = state;
        }
    }
}