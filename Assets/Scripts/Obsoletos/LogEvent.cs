using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LogEvent : MonoBehaviour
{
    public static event Action onPickUp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onPickUp?.Invoke();
            Destroy(gameObject);
        }
    }
}
