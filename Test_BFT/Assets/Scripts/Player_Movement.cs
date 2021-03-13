using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    float HorizontalInputValue;
    float VerticalInputValue;
    float SteeringAngle;


    [Header("WheelCollider")]
    [SerializeField] WheelCollider frontDriverW;
    [SerializeField] WheelCollider frontPassengerW;
    [SerializeField] WheelCollider backDriverW;
    [SerializeField] WheelCollider backPassengerW;

    [Header("Transform Wheel")]
    [SerializeField] Transform frontDriverT;
    [SerializeField] Transform frontPassengerT;
    [SerializeField] Transform backDriverT;
    [SerializeField] Transform backPassengerT;

    [Space(10)]
    [SerializeField] float maxSteerAngle;
    [SerializeField] float MotorForce;

    Rigidbody Rb;

    private void Awake()
    {
        Rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
        UpdateWheePoses();
        Debug.Log(Rb.velocity.magnitude);
    }

    void GetInput()
    {
        HorizontalInputValue = Input.GetAxis("Horizontal");
        VerticalInputValue = Input.GetAxis("Vertical");
    }

    void Steer()
    {
        SteeringAngle = maxSteerAngle * HorizontalInputValue;
        frontDriverW.steerAngle = SteeringAngle;
        frontPassengerW.steerAngle = SteeringAngle;
    }

    void Accelerate()
    {
        frontDriverW.motorTorque = VerticalInputValue * MotorForce;
        frontPassengerW.motorTorque = VerticalInputValue * MotorForce;
    }

    void UpdateWheelPose(WheelCollider mycollider, Transform mytransform)
    {
        Vector3 pos = mytransform.position;
        Quaternion quat = mytransform.rotation;

        mycollider.GetWorldPose(out pos, out quat);

        mytransform.position = pos;
        mytransform.rotation = quat;
        
    }

    void UpdateWheePoses()
    {
        UpdateWheelPose(frontDriverW, frontDriverT);
        UpdateWheelPose(frontPassengerW, frontPassengerT);
        UpdateWheelPose(backDriverW, backDriverT);
        UpdateWheelPose(backPassengerW, backPassengerT);
    }
}
