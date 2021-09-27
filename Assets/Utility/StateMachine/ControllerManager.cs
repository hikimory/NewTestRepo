using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using VR.Toolkit;

public class ControllerManager : MonoBehaviour
{

    [SerializeField] private InputHelpers.Button m_teleportButton = InputHelpers.Button.None;
    [SerializeField] private StateMachine m_leftStateMachine = null;
    [SerializeField] private StateMachine m_rightStateMachine = null;

    private InputDevice _rightController;
    private InputDevice _leftController;


    protected void OnEnable()
    {
        InputDevices.deviceConnected += RegisterDevices;
    }

    protected void OnDisable()
    {
        InputDevices.deviceConnected -= RegisterDevices;
    }

    void RegisterDevices(InputDevice connectedDevice)
    {
        if (connectedDevice.isValid)
        {

            if ((connectedDevice.characteristics & InputDeviceCharacteristics.Left) != 0)
            {
                _leftController = connectedDevice;
            }
            else if ((connectedDevice.characteristics & InputDeviceCharacteristics.Right) != 0)
            {
                _rightController = connectedDevice;
            }
        }
    }

    private void Update()
    {
        m_leftStateMachine.Update();
        m_rightStateMachine.Update();
        if (_leftController.isValid)
        {
            if(_leftController.IsPressed(m_teleportButton, out var activated))
            {
                if(activated)
                {
                    if(m_leftStateMachine.CanTransact(TypeState.Teleport) && m_leftStateMachine.isActiveOnUI == false)
                        m_leftStateMachine.Transact(TypeState.Teleport);
                }
                else 
                {
                    if(m_leftStateMachine.CheckCurrentState(TypeState.Teleport) && m_leftStateMachine.CanTransact(TypeState.Idle))
                        m_leftStateMachine.Transact(TypeState.Idle);
                }
                
            }
        }

        if (_rightController.isValid)
        {
            if (_rightController.IsPressed(m_teleportButton, out var activated))
            {
                if(activated)
                {
                    if (m_rightStateMachine.CanTransact(TypeState.Teleport) && m_rightStateMachine.isActiveOnUI == false)
                        m_rightStateMachine.Transact(TypeState.Teleport);
                }
                else 
                {
                    if(m_rightStateMachine.CheckCurrentState(TypeState.Teleport) && m_rightStateMachine.CanTransact(TypeState.Idle))
                        m_rightStateMachine.Transact(TypeState.Idle);
                }
            }
        }
    }
}
