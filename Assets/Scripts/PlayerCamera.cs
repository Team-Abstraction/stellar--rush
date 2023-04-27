using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform cameraHolder;

    public void LateUpdate()
    {
        cameraHolder.position = new Vector3(transform.position.x, transform.position.y, cameraHolder.position.z);
    }
}
