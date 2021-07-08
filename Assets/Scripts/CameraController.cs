using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoSingleton<CameraController>
{
    public Vector3 cameraSetting;
    public Transform startPosition;

    void Update()
    {
        transform.position = startPosition.position + cameraSetting;
    }
}
