using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject followTarget;

    public Vector3 Offset;


    private void LateUpdate()
    {
        transform.position = followTarget.transform.position + Offset;
        transform.LookAt(followTarget.transform);
    }
}
