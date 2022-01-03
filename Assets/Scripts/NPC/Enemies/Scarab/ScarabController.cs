using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScarabController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private AudioClip clip;
    [SerializeField] private ScarabData scarabData;
    [SerializeField] private ParticleSystem earthquake;
    private ScarabPatrol patrol;
    private ScarabChase chase;
    private ScarabAtack atack;
    private AudioSource audioSource;
    private Animator anim;
    private bool canAtack = false;
    private float timeToAtack;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        patrol = GetComponent<ScarabPatrol>();
        chase = GetComponent<ScarabChase>();
        atack = GetComponent<ScarabAtack>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        timeToAtack += Time.deltaTime;

        PatrolChaseAttackAnim();

        if (DistanceToPlayer() <= scarabData.visionRange)
        {
            if (DistanceToPlayer() >= scarabData.minimumDistanceToPlayer)
                chase.Chase();
            else
            {
                if (canAtack)
                {
                    atack.Atack();
                    anim.SetTrigger(scarabData.atackType);
                    if (scarabData.atackType == "HeavyAttack")
                    {
                        audioSource.PlayOneShot(clip);
                        earthquake.Play();
                    }
                        
                    canAtack = false;
                    timeToAtack = 0f;
                }
                else
                    atack.LookAtPlayer();

                if (timeToAtack >= scarabData.hitCooldown)
                    canAtack = true;
            }
        }
        else
        {
            patrol.Patrol();
            patrol.CreateNewWay();
        }
    }
    
    private float DistanceToPlayer()
    {
        return Vector3.Distance(transform.position, player.transform.position);
    }

    private void PatrolChaseAttackAnim()
    {
        anim.SetFloat("DistanceToPlayer", Vector3.Distance(player.position, transform.position));
    }

    private void OnDrawGizmos()
    {
        if (DistanceToPlayer() <= scarabData.visionRange)
            Gizmos.color = Color.red;
        else
            Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position, scarabData.visionRange);
    }
}
