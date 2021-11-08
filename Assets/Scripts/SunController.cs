using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunController : MonoBehaviour
{

    [SerializeField] Vector3 cicleSpeed;

    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = cicleSpeed;
    }

    
    void Update()
    {
        
    }
}
