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

    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;

    private Rigidbody rb;

    private bool isShoot;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        mousePressDownPos = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        mouseReleasePos = Input.mousePosition;
        Shoot(mouseReleasePos - mousePressDownPos);
    }

    private float forceMultiplier = 1f;
   
    void Shoot(Vector3 Force)
    {
        if(!EventSystem.current.IsPointerOverGameObject())
        {
            OnShoot?.Invoke();
            if (isShoot)
                return;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(Force.x, Force.y, Force.y) * forceMultiplier);
            isShoot = true;
        }
    }

}
