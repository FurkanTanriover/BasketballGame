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

    public int invicBallDelay = 3;
    private int bounceCounter = 0;

    void Start()
    {
        ballColor = GetComponent<MeshRenderer>();
        ballMass = GetComponent<Rigidbody>();
        ballScale = GetComponent<Transform>();

        ballColor.material.color = ballType.ballColor;
        ballMass.mass = ballType.ballMass;
        transform.localScale = ballType.ballScale;
    }

    public void ResetBounceCounter()
    {
        bounceCounter = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("scoretrigger"))
        {
            ScoreAction?.Invoke();
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            bounceCounter++;
            if (bounceCounter >= 4)
            {
                StartCoroutine(InvicBallDelay());
            }
        }
    }

    private IEnumerator InvicBallDelay()
    {
        yield return new WaitForSeconds(invicBallDelay);
        gameObject.SetActive(false);

    }
}
