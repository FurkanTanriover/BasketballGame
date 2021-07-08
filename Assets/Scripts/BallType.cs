using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BallType", menuName = "Ball Type")]
public class BallType : ScriptableObject
{
    public Color ballColor = Color.white;
    public Vector3 ballScale = Vector3.one;
    public string typeName = "type";
    public float ballMass = 5f;
}
