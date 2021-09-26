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
        if (_leftController.isValid)
        {
            if(_leftController.IsPressed(m_teleportButton, out var value))
            {
                if(m_leftStateMachine.CanTransact(TypeState.Teleport))
                {
                    m_leftStateMachine.Transact(TypeState.Teleport);
                }

                //Press trigger
            }
        }

        if (_rightController.isValid)
        {
            if (_rightController.IsPressed(m_teleportButton, out var value))
            {
                if (m_rightStateMachine.CanTransact(TypeState.Teleport))
                {
                    m_rightStateMachine.Transact(TypeState.Teleport);
                }
            }
        }
    }
}
