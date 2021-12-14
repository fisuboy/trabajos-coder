using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZoneController : MonoBehaviour
{
    [SerializeField] private IguanaController iguana;
    [SerializeField] private IguanaColorController iguanaColor;
    [SerializeField] private SkinnedMeshRenderer iguanaSMR;

    private void Awake()
    {
        IguanaController.onHighSunZoneExit += OnHighSunZoneExitHandler;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            iguana.HighSunZone();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            iguana.HighSunZone();
        }
    }

    private void OnHighSunZoneExitHandler()
    {
        iguanaColor.HeatDown(iguanaSMR.material.color);
    }
}
