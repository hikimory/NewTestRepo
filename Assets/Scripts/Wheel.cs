using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    [SerializeField] private WheelSnap[] m_snapPoints = null;

    [SerializeField] private GameObject m_leftHand = null;
    [SerializeField] private GameObject m_rightHand = null;

    [SerializeField] private float _offset = 0.0f;
    
    private WheelSnap _leftSnap = null;
    private WheelSnap _rightSnap = null;

    private Rigidbody _rigidbody;
    private Vector3 _oldPosition;

    private void Start()
    {
        _rigidbody = this.GetComponent<Rigidbody>();
        _oldPosition = this.transform.localPosition;
    }

    private void Update() {
        if (_leftSnap != null && _rightSnap != null)
            Drag();
    }

    private void OnEnable()
    {
        if (m_snapPoints == null)
            return;
        
        foreach (var snap in m_snapPoints)
        {
            snap.onSelectEntering += OnSnapSelected;
            snap.onSelectExiting += OnSnapReleased;
        }
    }

    private void OnDisable()
    {
        if (m_snapPoints == null)
            return;
        
        foreach (var snap in m_snapPoints)
        {
            snap.onSelectEntering -= OnSnapSelected;
            snap.onSelectExiting -= OnSnapReleased;
        }
    }

    private void OnSnapSelected(WheelSnap snap)
    {
        if (_leftSnap == null && snap.SnapType == SnapType.Left)
        {
            _leftSnap = snap;
            snap.SetHandToSnap(m_leftHand);
        }
        if (_rightSnap == null && snap.SnapType == SnapType.Right)
        {
            _rightSnap = snap;
            snap.SetHandToSnap(m_rightHand);
        }
    }

    private void OnSnapReleased(WheelSnap snap)
    {
        if (_leftSnap == snap && snap.SnapType == SnapType.Left)
        {
            _leftSnap = null;
            snap.ReleaseHandToSnap(m_leftHand);
        }
        if (_rightSnap == snap && snap.SnapType == SnapType.Right)
        {
            _rightSnap = null;
            snap.ReleaseHandToSnap(m_rightHand);
        }
            
    }

    private void Drag()
    {
        if (CheckDistance())
        {
            Vector3 leftHandPosition = _leftSnap.HandParent.position;
            Vector3 rightHandPosition = _rightSnap.HandParent.position;
            Debug.Log("leftHandPosition" + leftHandPosition.ToString());
            Debug.Log("rightHandPosition" + rightHandPosition.ToString());
            Vector3 result = (leftHandPosition + rightHandPosition) / 2;
            Debug.Log("resultPosition" + result.ToString());
            //get handPosition
            //move object
            _rigidbody.MovePosition(result);
        }
        else
        {
            _leftSnap.ForceRelease(m_leftHand);
            _rightSnap.ForceRelease(m_rightHand);
        }
    }

    private bool CheckDistance()
    {
        float distance = Vector3.Distance(_oldPosition, this.transform.localPosition);
        Debug.Log("distance");
        Debug.Log(distance);
        return distance <= _offset;
    }
}
