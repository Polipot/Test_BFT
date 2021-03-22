using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Target;
    public float PositionSmoothTime;
    public float RotationSmoothTime;

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
        this.transform.position = Vector3.SmoothDamp(this.transform.position, Target.position, ref positionSmoothDampvelocity, PositionSmoothTime);

        float rotationSmoothDampVelocity = 0f;
        this.transform.rotation = Quaternion.Euler(new Vector3(0f, Mathf.SmoothDamp(this.transform.rotation.eulerAngles.y, target.rotation.eulerAngles.y, ref rotationSmoothDampVelocity, RotationSmoothTime), 0f));
    }

}
