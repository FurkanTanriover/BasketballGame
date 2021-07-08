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

    [SerializeField]
    private float throwForceInX = 1f, throwForceInY = 1f, throwForceInZ = 50f;
    private float touchTimeStart, touchTimeEnd, timeInterval;
    private Vector2 startPosition, endPosition, ballDirection;
    private Rigidbody rb;
    public bool isShoot = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchTimeStart = Time.time;
            startPosition = Input.mousePosition;
        }
    }

    private void OnMouseUp()
    {
        if (Input.GetMouseButtonUp(0))
        {
            touchTimeEnd = Time.time;
            timeInterval = touchTimeEnd - touchTimeStart;

            endPosition = Input.mousePosition;

            ballDirection = startPosition - endPosition;
        }
        Shoot();
    }


    void Shoot()
    {
        if (!GameManager.Instance.CheckEndGame() && GameManager.Instance.canShoot && !isShoot)
        {
            float SpeedY = LevelController.Instance.levelList[LevelController.Instance.levelCounter].yForce;
            float SpeedZ = LevelController.Instance.levelList[LevelController.Instance.levelCounter].zForce;

            float xForce = Mathf.Clamp(-ballDirection.x * throwForceInX, -5, 5);
            float yForce = Mathf.Clamp(-ballDirection.y * throwForceInY, 100, 700 + SpeedY);
            float zForce = ((throwForceInZ + SpeedZ) / timeInterval);


            LevelController.Instance.amount--;

            UIManager.Instance.BallAmountPanel();
            OnShoot?.Invoke();

            rb.AddForce(xForce, yForce, zForce);
            isShoot = true;
            GameManager.Instance.CheckEndGame();
        }
    }
}
