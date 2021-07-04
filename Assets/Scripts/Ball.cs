using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private BallType ballType = null;
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


    void Update()
    {
        
    }
}
