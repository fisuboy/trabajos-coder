using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScarabController : MonoBehaviour
{
    [SerializeField] private Transform waypoint;
    [SerializeField] private Transform reference;
    [SerializeField] private GameObject player;
    [SerializeField] private float aloneSpeed;
    [SerializeField] private float chaseSpeed;
    [SerializeField] private float minimumDistance;
    [SerializeField] private float lerpSpeed;
    [SerializeField] private float visionRange;
    [SerializeField] private float distanceToPlayer;
    [SerializeField] private int hitCooldown;
    [SerializeField] private int changeCooldown; 
    [SerializeField] private float xArea;
    [SerializeField] private float zArea;
    [SerializeField] Animator anim;

    private float timeToAtack = 2f;
    private float timeToChange = 0f;
    private float xIndex;
    private float zIndex;
    private bool canAtack = false;
    private bool inRange = false;
    private bool canChange = false;

    void Start()
    {

    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= visionRange)
            inRange = true;
        
        else
            inRange = false;
        

        if (inRange)
        {
            if (Vector3.Distance(transform.position, player.transform.position) >= distanceToPlayer)
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
                    

                if (timeToAtack >= hitCooldown)
                    canAtack = true;
            }
        }
        else
        {
            anim.SetBool("isRun", false);
            AloneMove();
            CreateNewWay();
        }
    }

    private void AloneMove()
    {
        Vector3 deltaVector = waypoint.position - transform.position;
        Vector3 direction = deltaVector.normalized;
        float distance = deltaVector.magnitude;
        transform.forward = Vector3.Lerp(transform.forward, direction, lerpSpeed * Time.deltaTime);
        transform.position += transform.forward * aloneSpeed * Time.deltaTime;
    }

    private void ChasePlayer()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        transform.forward = Vector3.Lerp(transform.forward, direction, lerpSpeed * Time.deltaTime);
        transform.position += transform.forward * chaseSpeed * Time.deltaTime;
    }

    private void AttackPlayer()
    {
        timeToAtack = 0;
        canAtack = false;
        player.GetComponent<IguanaController>().GetDamage();
    }

    private void CreateNewWay()
    {
        if (Vector3.Distance(transform.position, waypoint.transform.position) <= 0.2f)
        {
            timeToChange = 0;
            xIndex = Random.Range((reference.transform.position.x - (xArea / 2)), (reference.transform.position.x + (xArea / 2)));
            zIndex = Random.Range((reference.transform.position.z - (zArea / 2)), (reference.transform.position.z + (zArea / 2)));
            waypoint.transform.position = new Vector3(xIndex, waypoint.transform.position.y, zIndex);
        }
        
        if (canChange)
        {
            canChange = false;
            timeToChange = 0;
            xIndex = Random.Range((reference.transform.position.x - (xArea / 2)), (reference.transform.position.x + (xArea / 2)));
            zIndex = Random.Range((reference.transform.position.z - (zArea / 2)), (reference.transform.position.z + (zArea / 2)));
            waypoint.transform.position = new Vector3(xIndex, waypoint.transform.position.y, zIndex);
        }
        else
            timeToChange += Time.deltaTime;
        

        if (timeToChange >= changeCooldown)
            canChange = true;
    }

    private void OnDrawGizmos()
    {
        if (inRange)
            Gizmos.color = Color.red;
        
        else
            Gizmos.color = Color.green;
        
        Gizmos.DrawWireSphere(transform.position, visionRange);
    }
}