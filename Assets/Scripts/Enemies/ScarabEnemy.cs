using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScarabEnemy : Enemies
{
    [SerializeField] Transform waypoint;
    [SerializeField] Transform reference;
    [SerializeField] ScarabSpecificData scarabData;
    private float xIndex;
    private float zIndex;
    private float timeToChange = 0f;
    private float timeToAtack = 2f;
    private bool canChange = false;
    private bool canAtack = false;
    

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
                ChasePlayer();
            }
            else
            {
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
                }


                if (timeToAtack >= scarabData.hitCooldown)
                    canAtack = true;
            }
        }
        else
        {
            anim.SetBool("isRun", false);
            Patrol();
            CreateNewWay();
        }
       
    }

    protected override void ChasePlayer()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        transform.forward = Vector3.Lerp(transform.forward, direction, scarabData.lerpSpeed * Time.deltaTime);
        transform.position += transform.forward * scarabData.chaseSpeed * Time.deltaTime;
    }

    protected override void Patrol()
    {
        Vector3 deltaVector = waypoint.position - transform.position;
        Vector3 direction = (waypoint.position - transform.position).normalized;
        float distance = deltaVector.magnitude;
        transform.forward = Vector3.Lerp(transform.forward, direction, scarabData.lerpSpeed * Time.deltaTime);
        transform.position += transform.forward * scarabData.aloneSpeed * Time.deltaTime;
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
            timeToChange = 0;
            xIndex = Random.Range((reference.transform.position.x - (scarabData.xArea / 2)), (reference.transform.position.x + (scarabData.xArea / 2)));
            zIndex = Random.Range((reference.transform.position.z - (scarabData.zArea / 2)), (reference.transform.position.z + (scarabData.zArea / 2)));
            waypoint.transform.position = new Vector3(xIndex, waypoint.transform.position.y, zIndex);
        }

        if (canChange)
        {
            canChange = false;
            timeToChange = 0;
            xIndex = Random.Range((reference.transform.position.x - (scarabData.xArea / 2)), (reference.transform.position.x + (scarabData.xArea / 2)));
            zIndex = Random.Range((reference.transform.position.z - (scarabData.zArea / 2)), (reference.transform.position.z + (scarabData.zArea / 2)));
            waypoint.transform.position = new Vector3(xIndex, waypoint.transform.position.y, zIndex);
        }
        else
            timeToChange += Time.deltaTime;
        

        if (timeToChange >= scarabData.changeCooldown)
            canChange = true;
    }  
}
