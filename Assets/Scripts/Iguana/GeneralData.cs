using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New GeneralData", menuName = "General Data")]
public class GeneralData : ScriptableObject
{
    public int life;
    public float speed;
    public float speedTurn;
    //public float jumpForce;
}
