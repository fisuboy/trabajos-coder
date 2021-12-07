using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScarabEnemy : Enemies
{
    [SerializeField] Transform waypoint;
    [SerializeField] Transform reference;
    [SerializeField] ScarabSpecificData scarabData;
    private float xIndex;
    private float zIndex;
    //private float timeToChange = 0f;
    private float timeToAtack = 2f;
    //private bool canChange = false;
    private bool canAtack = true;
    private int i;

    public static event Action onHit;
    //public static event Action onAproach;
    

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= data.visionRange)
            inRange = true;
        else
            inRange = false;

        if (inRange)
        {
            if (Vector3.Distance(transform.position, player.transform.position) >= scarabData.distanceToPlayer)
            {
                anim.SetBool("isRun", true);
                anim.SetBool("isIdle", false);
                MoveToTarget(player, scarabData.chaseSpeed);
            }
            else
            {
                if (timeToAtack >= scarabData.hitCooldown)
                    canAtack = true;

                if (canAtack)
                {
                    anim.SetBool("isIdle", true);
                    anim.SetTrigger("Attack");
                    AttackPlayer();
                }
                else
                {
                    anim.SetBool("isIdle", true);
                    timeToAtack += Time.deltaTime;
                    LookAtTarget(player);
                }
            }
        }
        else
        {
            anim.SetBool("isRun", false);
            MoveToTarget(waypoint, scarabData.aloneSpeed);
            CreateNewWay();
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onHit?.Invoke();
        }
        
    }

    protected override void ChasePlayer()
    {
        

    }

    protected override void Patrol()
    {
        
    }

    protected override void AttackPlayer()
    {
        timeToAtack = 0;
        canAtack = false;
    }

    private void CreateNewWay()
    {
        if (Vector3.Distance(transform.position, waypoint.transform.position) <= 0.2f)
        {
            xIndex = UnityEngine.Random.Range((reference.transform.position.x - (scarabData.xArea / 2)), (reference.transform.position.x + (scarabData.xArea / 2)));
            zIndex = UnityEngine.Random.Range((reference.transform.position.z - (scarabData.zArea / 2)), (reference.transform.position.z + (scarabData.zArea / 2)));
            waypoint.transform.position = new Vector3(xIndex, waypoint.transform.position.y, zIndex);
        }
    }
}
