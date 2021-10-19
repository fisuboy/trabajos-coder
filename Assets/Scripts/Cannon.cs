using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject bala;
    
    
    void Start()
    {
        
    }
        
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Disparo();
        }
    }

    public void Disparo()
    {
        Instantiate(bala, transform.position, transform.rotation);
    }
}
