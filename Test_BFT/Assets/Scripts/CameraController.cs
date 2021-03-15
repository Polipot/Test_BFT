using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player;
    public Transform TargetCamera;
    //public GameObject CameraFolder;
    public Transform CameLocation;
    //public int locationIndicator = 2;

    public Player_Movement controllerRef;

    [Range(0, 1)] public float smoothTime = .5f;

    private Rigidbody playerRb;

    void Start()
    {
        //Player = GameObject.FindGameObjectWithTag("Player").transform;
        //TargetPlayer = GameObject.FindGameObjectWithTag.;
        //CameraFolder = Camera.main.gameObject;

        controllerRef = Player.GetComponent<Player_Movement>();
        playerRb = Player.GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        //if (Input.GetKeyDown(KeyCode.Tab))
        //{
        //    if (locationIndicator >= 4 || locationIndicator < 2) 
        //        locationIndicator = 2;
        //    else locationIndicator++;
        //}

        transform.position = CameLocation.position * (1 - smoothTime) + transform.position * smoothTime;
        transform.LookAt(TargetCamera);

        //Vector3 KPH = playerRb.velocity;

        smoothTime = (playerRb.velocity.x >= 2) ? Mathf.Abs((playerRb.velocity.x) / 9) - 0.85f : -0.60f;
    }
}
