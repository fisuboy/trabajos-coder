using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    [SerializeField] private GameObject light;
    private bool lightToggle = false;
        
    void Start()
    {
        
    }

    void Update()
    {
        light.SetActive(lightToggle);
        ToggleOnOff();
    }

    private void ToggleOnOff()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            lightToggle = !lightToggle;
        }
    }
}
