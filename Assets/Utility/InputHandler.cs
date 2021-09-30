using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public static class InputHandler
{
    public static Dictionary<XRController, List<XRButton>> controllerButtons = new Dictionary<XRController, List<XRButton>>();
    
    public static bool GetKeyUp(XRController controller, InputFeatureUsage<bool> feature)
    {
        return GetButtonstatus(controller, feature, PressType.End);
    }

    public static bool GetKeyDown(XRController controller, InputFeatureUsage<bool> feature)
    {
        return GetButtonstatus(controller, feature, PressType.Begin);
    }

    private static bool GetButtonstatus(XRController controller, InputFeatureUsage<bool> feature, PressType type)
    {
        XRButton btn = GetControllerButton(controller, feature);
        
        if(btn != null)
            return btn.GetStatus(controller.inputDevice, type);

        return false;
    }

    private static XRButton GetControllerButton(XRController controller, InputFeatureUsage<bool> feature)
    {
        if(controllerButtons.ContainsKey(controller) == false)
        {
            controllerButtons.Add(controller, new List<XRButton>());
        }

        if(IsContaintButton(controller, feature) == false)
        {
            AddControllerButton(controller, feature, out XRButton button);
            return button;
        }

        return GetButton(controller, feature);
    }

    private static bool IsContaintButton(XRController controller, InputFeatureUsage<bool> feature)
    {
        return controllerButtons[controller].Where(x => x.feature == feature).Any();
    }

    private static XRButton GetButton(XRController controller, InputFeatureUsage<bool> feature)
    {
        return controllerButtons[controller].Where(x => x.feature == feature).First();
    }
    
    private static void AddControllerButton(XRController controller, InputFeatureUsage<bool> feature, out XRButton button)
    {
        button = new XRButton();
        button.feature = feature;
        controllerButtons[controller].Add(button);
    }

    private static void RemoveControllerButton(XRController controller, InputFeatureUsage<bool> feature)
    {
        controllerButtons[controller].Remove(GetButton(controller, feature));
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

