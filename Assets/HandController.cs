using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class HandController : MonoBehaviour
{
    
    [SerializeField] 
    private Animator _handAnimator;
    
    [SerializeField] 
    private XRController _controller;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateHandAnimation();
    }

    void UpdateHandAnimation()
    {
        if(_controller.inputDevice.TryGetFeatureValue(CommonUsages.grip, out float value))
        {
            _handAnimator.SetFloat("Grip", value);
        }
    }
}
