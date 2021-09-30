using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportManager : MonoBehaviour
{
    
    [SerializeField] private XRController m_controller;
    [SerializeField] private XRRayInteractor m_interactor;
    [SerializeField] private XRInteractorLineVisual m_lineVisual;
    [SerializeField] private ControllerType m_controllerType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(InputHandler.GetKeyUp(m_controller, CommonUsages.triggerButton))
        {
            Debug.Log("GetKeyUp Trigger");
            SetStatus(false);
        }
        if(InputHandler.GetKeyDown(m_controller, CommonUsages.triggerButton))
        {
            Debug.Log("GetKeyDown Trigger");
            SetStatus(true);
        }
    }

    private void SetStatus(bool state)
    {
        m_lineVisual.enabled = state;
        m_interactor.allowHover = state;
        m_interactor.allowSelect = state;
    }
}
