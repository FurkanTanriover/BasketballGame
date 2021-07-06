using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class SwipeController : MonoSingleton<SwipeController>
{
    public static event Action OnShoot;

    //private Vector3 mousePressDownPos;
    //private Vector3 mouseReleasePos;

    [SerializeField]
    private float throwForceInX = 1f, throwForceInY = 1f, throwForceInZ = 50f;
    private float touchTimeStart, touchTimeEnd, timeInterval;

    private Vector2 startPosition, endPosition, ballDirection;

    private Rigidbody rb;

    private bool isShoot;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        if(Input.GetMouseButtonDown(0))
        {
            touchTimeStart = Time.time;
            startPosition = Input.mousePosition;
        }
    }

    private void OnMouseUp()
    {
        if(Input.GetMouseButtonUp(0))
        {
            touchTimeEnd = Time.time;
            timeInterval = touchTimeEnd - touchTimeStart;

            endPosition = Input.mousePosition;

            ballDirection = startPosition - endPosition;
        }

        Shoot();

    }

    //private float forceMultiplier = 1f;
   
    void Shoot()
    {
        float SpeedY = LevelController.Instance.yForce;
        float SpeedZ = LevelController.Instance.zForce;

        float xForce = Mathf.Clamp(-ballDirection.x * throwForceInX, -5, 5);
        float yForce = Mathf.Clamp(-ballDirection.y * throwForceInY, 100, 700 + SpeedY);
        float zForce = ((throwForceInZ + SpeedZ) / timeInterval);

        OnShoot?.Invoke();
        if (isShoot)
            return;
        rb.isKinematic = false;
        rb.AddForce(xForce, yForce, zForce);
        isShoot = true;

    }

}
