using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cañon : MonoBehaviour
{
    public GameObject bala;
    
    // Start is called before the first frame update
    void Start()
    {
        Disparo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Disparo()
    {
        Instantiate(bala, transform.position, transform.rotation);
    }
}
