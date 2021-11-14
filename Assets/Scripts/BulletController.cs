using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float bulletTime;

    void Start()
    {
        
    }

    void Update()
    {
        BulletTime();
    }

    private void BulletTime()
    {
        bulletTime -= Time.deltaTime;
        if (bulletTime < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
