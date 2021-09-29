using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public static class InputHandler
{

    public static bool GetKeyUp(ControllerType controllerType, XRController controller, ButtonType type)
    {
        XRButton btn = XRButtons.Instance.GetButtonByKey(controllerType, type);
        return btn != null ? btn.GetStatus(controller.inputDevice, PressType.End) : false;
    }

    public static bool GetKeyDown(ControllerType controllerType, XRController controller, ButtonType type)
    {
        XRButton btn = XRButtons.Instance.GetButtonByKey(controllerType, type);
        return btn != null ? btn.GetStatus(controller.inputDevice, PressType.Begin) : false;
    }


}

public enum ButtonType
{
    Trigger,
    Grip,
    Primary,
    PrimaryTouch,
    Secondary,
    SecondaryTouch,
    Primary2DAxisClick,
    Primary2DAxisTouch
}
 
public enum PressType
{
    Begin,
    End,
    Continuous
}

