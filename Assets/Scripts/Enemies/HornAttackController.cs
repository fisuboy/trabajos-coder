using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HornAttackController : MonoBehaviour
{
    public static event Action onHit;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            onHit?.Invoke();
    }
}
