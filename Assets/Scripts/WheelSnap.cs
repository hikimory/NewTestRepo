using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public enum SnapType : uint
{
    Undefined = 0,
    Left = 1,
    Right = 2
}

public class WheelSnap : XRBaseInteractable
{
    [SerializeField] private Transform m_attachPoint = null;
    [SerializeField] private XRDirectInteractor m_targetInteractor = null;
    [SerializeField] private SnapType m_snapType = SnapType.Undefined;


    public XRDirectInteractor TargetInteractor => m_targetInteractor;
    public SnapType SnapType => m_snapType;
    public event UnityAction<WheelSnap> onSelectEntering;
    public event UnityAction<WheelSnap> onSelectExiting;

    private Vector3 _oldPosition = Vector3.zero;
    private Quaternion _oldRotation = Quaternion.identity;

    private Vector3 _oldScale = new Vector3(1, 1, 1);

    public Transform HandParent
    {
        get
        {
            return m_targetInteractor.transform;
        }
    }

    protected override void OnSelectEntering(XRBaseInteractor interactor)
    {
        base.OnSelectEntering(interactor);
        print(interactor is XRDirectInteractor);
        if (interactor is XRDirectInteractor == false)
            return;
        
        if (interactor as XRDirectInteractor == m_targetInteractor)
            onSelectEntering?.Invoke(this);
    }

    protected override void OnSelectExiting(XRBaseInteractor interactor)
    {
        base.OnSelectExiting(interactor);
        print(interactor is XRDirectInteractor);
        if (interactor is XRDirectInteractor == false)
            return;
        
        if (interactor as XRDirectInteractor == m_targetInteractor)
            onSelectExiting?.Invoke(this);
    }
    
    
    public void SetHandToSnap(GameObject hand)
    {
        if(hand == null) return;

        _oldPosition = hand.transform.localPosition;
        _oldRotation = hand.transform.localRotation;

        hand.transform.SetParent(m_attachPoint);
        hand.transform.localPosition = Vector3.zero;
        hand.transform.rotation = m_attachPoint.rotation;
        hand.transform.localScale = _oldScale;
    }

    public void ReleaseHandToSnap(GameObject hand)
    {
        if(hand == null) return;

        hand.transform.SetParent(m_targetInteractor.transform);
        hand.transform.localPosition = _oldPosition;
        hand.transform.localRotation = _oldRotation;
        hand.transform.localScale = _oldScale;
    }

    public void ForceRelease(GameObject hand)
    {
        ReleaseHandToSnap(hand);
    }

}
