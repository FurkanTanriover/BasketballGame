using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ball : MonoSingleton<Ball>
{
    [SerializeField] private BallType ballType = null;
    public static event Action ScoreAction;

    private MeshRenderer ballColor;
    private Rigidbody ballMass;
    private Transform ballScale;

    void Start()
    {
        ballColor = GetComponent<MeshRenderer>();
        ballMass = GetComponent<Rigidbody>();
        ballScale = GetComponent<Transform>();

        ballColor.material.color = ballType.ballColor;
        ballMass.mass = ballType.ballMass;
        transform.localScale = ballType.ballScale;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("scoretrigger"))
        {
            ScoreAction?.Invoke();
            Debug.Log("Score!!");
        }
    }


    void Update()
    {
        
    }
}
