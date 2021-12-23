using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IguanaAttack : MonoBehaviour
{
    [SerializeField] private GeneralData data;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask enemies;
    private Animator animPlayer;
    private float attackRate = 2f;
    private float nextAttackTime = 0f;

    void Start()
    {
        animPlayer = GetComponent<Animator>();
    }

   
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    private void Attack()
    {
        animPlayer.SetTrigger("Attack");
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, data.attackRange, enemies);
        foreach (Collider enemy in hitEnemies)
        {
            Debug.Log("Hit" + enemy.name);
            enemy.GetComponent<HealthController>().TakeDamage(data.attackDamage);
        }
    }

    private void OnDrawGizmos()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, data.attackRange);
    }
}
