using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Level Type", menuName ="Level Type")]
public class LevelType : ScriptableObject
{
    public int balltype;
    public Vector3 startPosition = Vector3.one;
}
