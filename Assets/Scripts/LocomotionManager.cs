using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LocomotionManager : MonoBehaviour
{
    public XRController leftTeleportRay;
    public XRController rightTeleportRay;
    public InputHelpers.Button teleportActivationButton;
    public float activationThreshold = 0.1f;

    public XRRayInteractor leftInteractorRay;
    public XRRayInteractor rightInteractorRay;

    public bool EnableLeftTeleport { get; set;} = true;
    public bool EnableRightTeleport { get; set;} = true;

    private Vector3 _pos = new Vector3();
    private Vector3 _norm = new Vector3();
    private int _index = 0;
    private bool _validTarget = false;

    private RaycastHit raycastHit;
    private GameObject canvas;
    
    // Update is called once per frame
    void Update()
    {
        if(leftTeleportRay)
        {
            bool isLeftIneractorRayHovering = leftInteractorRay.TryGetHitInfo(out _pos, out _norm, out _index, out _validTarget);
            leftTeleportRay.gameObject.SetActive(EnableLeftTeleport && CheckIfActivated(leftTeleportRay) && !isLeftIneractorRayHovering );
        }

        if(rightTeleportRay)
        {
            bool isRightIneractorRayHovering = rightInteractorRay.TryGetHitInfo(out _pos, out _norm, out _index, out _validTarget);
            rightTeleportRay.gameObject.SetActive(EnableRightTeleport && CheckIfActivated(rightTeleportRay) && !isRightIneractorRayHovering);
        }
    }

    public bool CheckIfActivated(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, teleportActivationButton, out bool isActivated, activationThreshold);
        return isActivated;
    }
}
