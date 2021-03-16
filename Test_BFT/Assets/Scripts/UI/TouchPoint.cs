using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPoint : MonoBehaviour
{
    Vector3 Far;

    private void Awake()
    {
        Far = new Vector3(10000, 1000, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            transform.position = Input.GetTouch(0).position;
        }
        else
        {
            if (transform.position != Far)
                transform.position = Far;
        }
    }
}
