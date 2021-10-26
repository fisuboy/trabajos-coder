using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] GameObject[] cameras;

    void Start()
    {
        
    }

    
    void Update()
    {
        CameraManagement();
    }

    private void CameraManagement()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            cameras[0].SetActive(true);
            cameras[1].SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            cameras[0].SetActive(false);
            cameras[1].SetActive(true);
        }
    }
}
