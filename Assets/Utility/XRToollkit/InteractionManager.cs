using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace VR.Toolkit
{
    public class InteractionManager : XRInteractionManager
    {
        public void ForceDeselect(XRBaseInteractor interactor)
        {
            if (interactor.selectTarget)
                SelectExit(interactor, interactor.selectTarget);
        }

        public void ForceDeselectAndDestroy(XRBaseInteractor interactor)
        {
            if (interactor.selectTarget)
            {
                GameObject obj = interactor.selectTarget.gameObject;
                SelectExit(interactor, interactor.selectTarget);
                Destroy(obj);
            }
        }
    }
}

