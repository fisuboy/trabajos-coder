using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ScarabSpecificData", menuName = "Scarab Specific Data")]

public class ScarabSpecificData : ScriptableObject
{
    public float xArea;
    public float zArea;
    public float aloneSpeed;
    public float chaseSpeed;
    public float lerpSpeed;
    public float distanceToPlayer;
    public float hitCooldown;
    public int changeCooldown;
}
