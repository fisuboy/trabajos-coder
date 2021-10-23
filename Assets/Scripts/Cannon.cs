using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject bullet;
    public float timeToMove;
    private float timeToMoveLeft;

    void Start()
    {
        ResetTimer();
    }
        
    void Update()
    {
        Temporizador();    
    }

    private void FireCannon()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }

    private void ResetTimer()
    {
        timeToMoveLeft = timeToMove;
    }
    private void Temporizador()
    {
        timeToMoveLeft -= Time.deltaTime;

        if (timeToMoveLeft <= 0)
        {
            FireCannon();
            ResetTimer();
        }
    }

}
