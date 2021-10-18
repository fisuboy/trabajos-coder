using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBala : MonoBehaviour
{
    public GameObject Bala;
    
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Bala, transform.position , Bala.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
