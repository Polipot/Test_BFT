using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    private Vector2 FirstPoint, SecondPoint, ThirdPoint;
    

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
    [SerializeField] float speed;
     float MotorForce;
    [SerializeField] float BrakeForce;
    bool IsBraked = true ;

    [SerializeField] Text debugText;
    [SerializeField] Text debugText2;

    [SerializeField] Transform CM;

    Rigidbody Rb;

    private void Awake()
    {
        Time.timeScale = 1;
        Rb = GetComponent<Rigidbody>();
       
    }
    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Brake();
        Accelerate();
        UpdateWheePoses();
        //Debug.Log(Rb.velocity.magnitude);
    }

    private void Update()
    {
        /*if (debugText != null)
            debugText.text = " freinage = " + VerticalInputValue;

        if (debugText2 != null)
            debugText2.text = " acceleration = " + frontDriverW.motorTorque;*/
    }    

    void GetInput()
    {
        

        if (Input.touchCount > 0 )
        {
            touch = Input.GetTouch(0);
            touchpos1 = touch.position;
            if (Firsttouch == true)
            {
                /*
                FirstPoint = Instantiate(Resources.Load<GameObject>("PointTouch"), touchpos1, Quaternion.identity);
                SecondPoint = Instantiate(Resources.Load<GameObject>("PointTouch"), touchpos1, Quaternion.identity);
                ThirdPoint = Instantiate(Resources.Load<GameObject>("PointTouch"), touchpos1, Quaternion.identity);*/
                FirstPoint = touchpos1;
                SecondPoint = touchpos1;
                ThirdPoint = touchpos1;

                Firsttouch = false;
            }
            SecondPoint = new Vector2(touchpos1.x, FirstPoint.y);
            ThirdPoint = new Vector2(FirstPoint.x, touchpos1.y);
            HorizontalInputValue = (SecondPoint.x - FirstPoint.x) / 20;
            HorizontalInputValue = Mathf.Clamp(Mathf.RoundToInt(HorizontalInputValue), -30, 30);
            VerticalInputValue = FirstPoint.y - ThirdPoint.y;
            VerticalInputValue = (Mathf.Clamp(VerticalInputValue, 0 , 500))/ 500 ;
            

            Debug.Log(touchpos1);
        }
        else
        {
            Firsttouch = true;
            HorizontalInputValue = 0;
            VerticalInputValue = 0;
        }
           
       /* if (Input.GetAxis("Horizontal") < 0)
        {
           HorizontalInputValue = -30;
        }else if (Input.GetAxis("Horizontal") > 0)
        {
            HorizontalInputValue = 30;
        }
        VerticalInputValue = Input.GetAxis("Vertical");*/
        //Debug.Log(VerticalInputValue);
    }

    void Steer()
    {
        if (HorizontalInputValue < -5 || HorizontalInputValue > 5)
        {
            SteeringAngle = HorizontalInputValue * 1;
            frontDriverW.steerAngle = SteeringAngle;
            frontPassengerW.steerAngle = SteeringAngle;
        }else
        {
            SteeringAngle = 0;
            frontDriverW.steerAngle = SteeringAngle;
            frontPassengerW.steerAngle = SteeringAngle;
        }
        
        
    }
   
    void Accelerate()
    {

        if (IsBraked == false)
        {

            if (Rb.velocity.magnitude <= 15)
            {
                Debug.Log("Accelere");
                MotorForce = speed;
            }
            else
            {

                MotorForce = 0;
            }

            //Debug.Log(backDriverW.motorTorque);
            //Debug.Log(Rb.velocity.magnitude);
        }
        else if (IsBraked == true ) MotorForce = 0;
        frontDriverW.motorTorque = MotorForce;
        frontPassengerW.motorTorque = MotorForce;
    }

    void Brake()
    {
        if (VerticalInputValue > 0.3 )
        {
            IsBraked = true;
            frontDriverW.brakeTorque = BrakeForce * VerticalInputValue;
            frontPassengerW.brakeTorque = BrakeForce * VerticalInputValue;
        }
        else 
        {
            IsBraked = false;
            frontDriverW.brakeTorque = 0;
            frontPassengerW.brakeTorque = 0;
        }
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

    public void TriggerPause()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        else
            Time.timeScale = 0;
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
