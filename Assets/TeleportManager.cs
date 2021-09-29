using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        if(InputHandler.GetKeyDown(m_controllerType, m_controller, ButtonType.Trigger))
        {
            Debug.Log("GetKeyDown Trigger");
        }
        if(InputHandler.GetKeyUp(m_controllerType, m_controller, ButtonType.Trigger))
        {
            Debug.Log("GetKeyUp Trigger");
        }
    }
}
