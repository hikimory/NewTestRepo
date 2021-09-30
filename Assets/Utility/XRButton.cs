using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

[System.Serializable]
public class XRButton
{
    public InputFeatureUsage<bool> feature;
    public bool isPressed;
    public bool wasPressed;
    public bool active = false;

    public bool GetStatus(InputDevice device, PressType pressType)
    {
        device.TryGetFeatureValue(feature, out isPressed);
        
        switch (pressType)
        {
            case PressType.Continuous: 
            { 
                active = isPressed;
                wasPressed = isPressed;
                break;
            }
            case PressType.Begin:
            {
                active = isPressed && !wasPressed; 
                wasPressed = isPressed;
                break;
            } 
            case PressType.End:
            {
                active = !isPressed && wasPressed; 
                wasPressed = false;
                break;
            } 
        }
        return active;
    }
}
