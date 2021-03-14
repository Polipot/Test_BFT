using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Movement : MonoBehaviour
{
    float HorizontalInputValue;
    float VerticalInputValue;
    float SteeringAngle;
    string NikTaMere;

    [Header("Input")]
    Touch touch;
    Vector2 touchpos1;
    bool Firsttouch = true;
    GameObject FirstPoint;
    GameObject SecondPoint;
    

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

    [SerializeField] Text debugText;

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
        //Debug.Log(Rb.velocity.magnitude);
    }

    private void Update()
    {
        //debugText.text = " valeur horizontale = " + HorizontalInputValue;
    }

    void GetInput()
    {
        

        if (Input.touchCount > 0 )
        {
            touch = Input.GetTouch(0);
            touchpos1 = touch.position;
            if (Firsttouch == true)
            {
                
                FirstPoint = Instantiate(Resources.Load<GameObject>("PointTouch"), touchpos1, Quaternion.identity);
                SecondPoint = Instantiate(Resources.Load<GameObject>("PointTouch"), touchpos1, Quaternion.identity);
                Firsttouch = false;
            }
            SecondPoint.transform.position = new Vector2(touchpos1.x, FirstPoint.transform.position.y);
            HorizontalInputValue = SecondPoint.transform.position.x - FirstPoint.transform.position.x;
            HorizontalInputValue = HorizontalInputValue / 20;
            HorizontalInputValue = Mathf.RoundToInt(HorizontalInputValue);
            HorizontalInputValue = Mathf.Clamp(HorizontalInputValue, -30, 30);

            Debug.Log(touchpos1);
        }
        else
        {
            Firsttouch = true;
            HorizontalInputValue = 0;
        }
           
        
        VerticalInputValue = Input.GetAxis("Vertical");
    }

    void Steer()
    {
        
        SteeringAngle = HorizontalInputValue * 1;
        frontDriverW.steerAngle = SteeringAngle;
        frontPassengerW.steerAngle = SteeringAngle;
    }

    // ça c'est juste pour moi Adri à l'heure qu'il est tu peux probablement dégager cette fonction et remettre la tienne
    

    void Accelerate()
    {
        backDriverW.motorTorque =   MotorForce;
        backPassengerW.motorTorque =  MotorForce;
        Debug.Log(frontDriverW.motorTorque);
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
