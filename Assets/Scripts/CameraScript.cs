using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform cameraTarget;
    public Vector3 offset;
    void Start()
    {
        cameraTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = cameraTarget.position + offset;
    }
}

