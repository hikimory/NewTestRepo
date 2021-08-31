using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] 
    private XRController _rightController;

    [SerializeField] 
    private float speed = 1;

    [SerializeField] 
    private LayerMask groundLayer;

    private XRRig rig;
    private Vector2 inputAxis;
    private CharacterController character;

    private float gravity = -9.81f;
    private float fallingSpeed;


    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        rig = GetComponent<XRRig>();
    }

    void Update() {
        UpdatePosition();
    }

    // Update is called once per frame
    void UpdatePosition()
    {
        _rightController.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
    }

    void FixedUpdate() {
        float cameraAngel = rig.cameraGameObject.transform.eulerAngles.y;
        Quaternion headRotation = Quaternion.Euler(0, cameraAngel, 0);
        Vector3 direction  = headRotation * new Vector3( inputAxis.x, 0, inputAxis.y);
        
        character.Move(direction * Time.fixedDeltaTime * speed);
        
        //gravity
        if(IsGrounded())
            fallingSpeed = 0;
        else
            fallingSpeed += gravity * Time.fixedDeltaTime;

        character.Move(Vector3.up * Time.fixedDeltaTime * fallingSpeed);
    }

    void CapsuleFollowHeadset()
    {
        character.height = rig.cameraInRigSpaceHeight;
        Vector3 capsuleCenter = transform.InverseTransformPoint(rig.cameraGameObject.transform.position);
        character.center = new Vector3(capsuleCenter.x, character.height / 2, capsuleCenter.z);
    }

    bool IsGrounded()
    {
        Vector3 start = transform.TransformPoint(character.center);
        float length = character.center.y + 0.01f;
        bool hasHit = Physics.SphereCast(start, character.radius, Vector3.down, out RaycastHit hitInfo, length, groundLayer);
        return hasHit;
    }
}
