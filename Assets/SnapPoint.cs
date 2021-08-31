using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class SnapPoint : XRSimpleInteractable
{
    [System.Serializable]
    public class MySnapPointEvent : UnityEvent<SnapPoint>{}
    public MySnapPointEvent m_MyEvent;

    [SerializeField]
    private XRDirectInteractor directInteractor;
    private XRBaseInteractor _interactor;
    
    public XRBaseInteractor Interactor
    {
        get
        {
            return _interactor;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        m_MyEvent = new MySnapPointEvent();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        if(interactor is XRDirectInteractor && interactor.Equals(directInteractor))
        {
            Debug.Log($"Interactor {interactor.transform.name} Grab");
            _interactor = interactor;
            m_MyEvent.Invoke(this);
        }
        base.OnSelectEntered(interactor);
    }
    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        if(interactor is XRDirectInteractor && interactor.Equals(directInteractor))
        {
            Debug.Log($"Interactor {interactor.transform.name} Release");
            _interactor = null;
        }
        base.OnSelectExited(interactor);
    }
}
