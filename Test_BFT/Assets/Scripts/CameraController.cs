using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject AtachedVehicule;
    public GameObject CameraFolder;
    public Transform[] CameLocation;
    public int locationIndicator = 2;

    public Player_Movement controllerRef;

    [Range(0, 1)] public float smoothTime = .5f;

    private Rigidbody playerRb;

    void Start()
    {
        AtachedVehicule = GameObject.FindGameObjectWithTag("Player");
        //CameraFolder = Camera.main.gameObject;
        CameLocation = CameraFolder.GetComponentsInChildren<Transform>();

        controllerRef = AtachedVehicule.GetComponent<Player_Movement>();
        playerRb = AtachedVehicule.GetComponent<Rigidbody>();
    }

    
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (locationIndicator >= 4 || locationIndicator < 2) 
                locationIndicator = 2;
            else locationIndicator++;
        }

        transform.position = CameLocation[locationIndicator].position * (1 - smoothTime) + transform.position * smoothTime;
        transform.LookAt(CameLocation[1].transform);

        //Vector3 KPH = playerRb.velocity;

        smoothTime = (playerRb.velocity.x >= 150) ? Mathf.Abs((playerRb.velocity.x) / 150) - 0.85f : 0.45f;
    }
}
