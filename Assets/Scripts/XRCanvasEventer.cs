using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRRayInteractor))]
public class XRCanvasEventer : MonoBehaviour
{
    [SerializeField] private ControllerType m_controllerType = ControllerType.Undefided;
    
    [Space(10f)] 
    public UnityEvent OnHoverEntered;
    public UnityEvent OnHoverExited;

    private XRRayInteractor _targetInteractor = null;
    private GameObject _howeredObject = null;

    private void Awake()
    {
        _targetInteractor = GetComponent<XRRayInteractor>();
    }

    private void OnEnable() 
    {
        Application.onBeforeRender += ProcessHovering;
    }

    private void OnDisable() 
    {
        Application.onBeforeRender -= ProcessHovering;
    }

    private void ProcessHovering()
    {
        if (_targetInteractor.TryGetCurrentUIRaycastResult(out var result))
        {
            if (_howeredObject == result.gameObject)
                return;
            
            _howeredObject = result.gameObject;

            if (HasInteractionTarget(result.gameObject))
            {
                Debug.Log("OnHoverEnter");
                OnHoverEntered?.Invoke();
            }
        }
        else
        {
            if (_howeredObject == null)
                return;
            
            _howeredObject = null;
            OnHoverExited?.Invoke();
            Debug.Log("OnHoverExit");
        }
    }

    /*private bool TryGetXRCanvas(GameObject raycastTarget, out XRCanvasTrigger canvas)
    {
        if (raycastTarget.TryGetComponentInParent<XRCanvasTrigger>(out var result))
        {
            canvas = result;
            return true;
        }

        canvas = null;
        return false;
    }*/

    private bool HasInteractionTarget(GameObject raycastTarget)
    {
        return (raycastTarget.TryGetComponentInParent<Canvas>(out var canvas) || raycastTarget.TryGetComponentInChildren<Image>(out var image));
    }
}

public enum ControllerType : uint
{
    Undefided = 0,
    Left = 1,
    Right = 2
}
