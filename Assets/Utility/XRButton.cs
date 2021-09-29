using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

[System.Serializable]
public class XRButton
{
    [SerializeField] private ButtonType m_button;

    public ButtonType TypeButton => m_button;
    public bool isPressed;
    public bool wasPressed;
    public bool active = false;

    public bool GetStatus(InputDevice device, PressType pressType)
    {
        device.TryGetFeatureValue(XRStatics.GetFeature(m_button), out isPressed);
        
        switch (pressType)
        {
            case PressType.Continuous: active = isPressed; break;
            case PressType.Begin: active = isPressed && !wasPressed; break;
            case PressType.End: active = !isPressed && wasPressed; break;
        }
        if(!isPressed && wasPressed) Debug.Log("WHY BITCH ???");
        wasPressed = isPressed;
        return active;
    }
}
