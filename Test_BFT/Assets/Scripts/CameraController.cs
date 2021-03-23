using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Target;
    public float SmoothTimePosition;
    public float SmoothTimeRotation;

    Transform pivot;
    Camera cam;

    private void Start()
    {
        pivot = transform.GetChild(0).transform;
        if (pivot == null)
            Debug.LogError("Pas de pivot correct dans ce gameObject");

        cam = pivot.GetChild(0).GetComponent<Camera>();
        if (cam == null)
            Debug.LogError("Pas decomponent Camera correct dans ce gameObject");
    }

    void FixedUpdate()
    {
        Vector3 positionSmoothDampvelocity = Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position, Target.position, ref positionSmoothDampvelocity, SmoothTimePosition);

        //float rotationSmoothDampVelocity = 0f;
        //transform.rotation = Quaternion.Euler(new Vector3(0f, Mathf.SmoothDamp(transform.localEulerAngles.y, Target.eulerAngles.y, ref rotationSmoothDampVelocity, RotationSmoothTime), 0f));
        transform.rotation = Quaternion.Lerp(transform.rotation, Target.rotation, Time.time * SmoothTimeRotation);
    }

}
