using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] GeneralData data;

    protected Vector3 direction;
    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void FixedUpdate()
    {
        
    }

    protected void Move()
    {
        rb.velocity = direction * data.speed;
    }
}
