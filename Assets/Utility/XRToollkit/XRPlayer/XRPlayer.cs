using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRPlayer : MonoBehaviour
{
    [SerializeField] private XRDirectInteractor m_leftDirectInteractor;
    [SerializeField] private XRRayInteractor m_leftTeleportRay;
    [SerializeField] private XRRayInteractor m_leftInteractorRay;

    [SerializeField] private XRDirectInteractor m_rightDirectInteractor;
    [SerializeField] private XRRayInteractor m_rightTeleportRay;
    [SerializeField] private XRRayInteractor m_rightInteractorRay;


    public static XRDirectInteractor LeftDirectInteractor => _instance.m_leftDirectInteractor;
    public static XRDirectInteractor RightDirectInteractor => _instance.m_rightDirectInteractor;

    public static XRRayInteractor LeftInteractorRay => _instance.m_leftInteractorRay;
    public static XRRayInteractor RightInteractorRay => _instance.m_rightInteractorRay;

    public static XRRayInteractor LeftTeleportRay => _instance.m_leftTeleportRay;
    public static XRRayInteractor RightTeleportRay => _instance.m_rightTeleportRay;

    private static XRPlayer _instance;
    
    public static XRPlayer Instance => _instance;


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        } else {
            _instance = this;
        }
    }
    
}
