using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public static class XRStatics
{
    public static InputFeatureUsage<bool> GetFeature(ButtonType button)
     {
         switch (button)
         {
             case ButtonType.Trigger: return CommonUsages.triggerButton;
             case ButtonType.Grip: return CommonUsages.gripButton;
             case ButtonType.Primary: return CommonUsages.primaryButton;
             case ButtonType.PrimaryTouch: return CommonUsages.primaryTouch;
             case ButtonType.Secondary: return CommonUsages.secondaryButton;
             case ButtonType.SecondaryTouch: return CommonUsages.secondaryTouch;
             case ButtonType.Primary2DAxisClick: return CommonUsages.primary2DAxisClick;
             case ButtonType.Primary2DAxisTouch: return CommonUsages.primary2DAxisTouch;
             default: Debug.LogError("button " + button + " not found"); return CommonUsages.triggerButton;      
         }
     }
}
