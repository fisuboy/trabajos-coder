using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] protected GeneralData data;
    [SerializeField] protected Transform player;
    [SerializeField] protected Animator anim;
    protected Rigidbody rb;
    protected float turnSmoothTime = 0.1f;
    protected float turnSmoothVelocity;
    protected bool inRange = false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    protected virtual void LookAtTarget(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
    }
    protected virtual void MoveToTarget(Transform target, float speed)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
        Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        transform.position += moveDir * speed * Time.deltaTime;
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
