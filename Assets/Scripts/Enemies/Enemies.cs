using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] protected GeneralData data;
    [SerializeField] protected Transform player;
    [SerializeField] protected Animator anim;
    protected Rigidbody rb;
    protected bool inRange = false;
        
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    protected virtual void Patrol()
    {
         
    }

    protected virtual void ChasePlayer()
    {
        
    }

    protected virtual void AttackPlayer()
    {

    }

    protected virtual void ReceiveDamage()
    {

    }

   

    protected void OnDrawGizmos()
    {
        if (inRange)
            Gizmos.color = Color.red;

        else
            Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position, data.visionRange);
    }
}
