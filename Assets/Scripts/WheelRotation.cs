using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotation : MonoBehaviour
{
    [SerializeField] private WheelSnap[] m_snapPoints = null;

    [SerializeField] private GameObject m_leftHand = null;
    [SerializeField] private GameObject m_rightHand = null;

    [Header( "Information" )]
    [SerializeField]
    private float _currentWheelRotation = 0f;
    [SerializeField]
    private Transform RotationPoint = null;
    
    private WheelSnap _leftSnap = null;
    private WheelSnap _rightSnap = null;

    private Rigidbody _rigidbody;
    private Vector3 _oldRotation;
    private Vector3 _newRotation;

    private void Start()
    {
        _rigidbody = this.GetComponent<Rigidbody>();
        SetOldRotation();
    }

    private void Update() {
        if (_leftSnap != null && _rightSnap != null)
            Rotate();

    }

    private void SetOldRotation()
    {
        _oldRotation = Vector3.zero;
        _newRotation = Vector3.zero;
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

    private void Rotate()
    {
        if (CheckDistance())
        {
            /*Vector3 leftHandPosition = _leftSnap.HandParent.position;
            Vector3 rightHandPosition = _rightSnap.HandParent.position;
            Vector3 middlePoint = (leftHandPosition + rightHandPosition) / 2;
            Debug.DrawRay(leftHandPosition, rightHandPosition - leftHandPosition, Color.magenta);
            middlePoint.z = transform.position.z;
            Vector3 direction = middlePoint - RotationPoint.position;
            Debug.DrawRay(RotationPoint.position, direction, Color.green);
            //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
            transform.up = direction;
            _currentWheelRotation = transform.rotation.z;*/
            
            Quaternion newRotLeft = Quaternion.Euler(0, 0, _leftSnap.HandParent.rotation.eulerAngles.z);
            Quaternion newRotRight = Quaternion.Euler(0, 0, _rightSnap.HandParent.rotation.eulerAngles.z);
            Quaternion finalRot = Quaternion.Slerp(newRotLeft, newRotRight, 0.5f);
            transform.rotation = finalRot;
        }
        else
        {
            _leftSnap.ForceRelease(m_leftHand);
            _rightSnap.ForceRelease(m_rightHand);
        }
    }

    private bool CheckDistance()
    {
        return transform.rotation.z < 120 && transform.rotation.z > -120;
    }

}

public enum Axis
{
    XAxis = 0,
    YAxis = 1,
    ZAxis = 2
}
