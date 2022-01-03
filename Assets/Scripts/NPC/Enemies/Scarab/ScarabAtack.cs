using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScarabAtack : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private Transform player;
    [SerializeField] private ScarabData scarabData;
    [SerializeField] private LayerMask playerLayer;
    private float turnSmoothVelocity;

    public void LookAtPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, scarabData.turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
    }

    public void Atack()
    {
        Collider[] hitPlayer = Physics.OverlapSphere(attackPoint.position, scarabData.attackRange, playerLayer);
        foreach (Collider player in hitPlayer)
        {
            Debug.Log("Hit" + player.name);
            if (scarabData.atackType == "SoftAttack")
            {
                player.GetComponent<IguanaController>().GetDamage(1);
            }
            else
            {
                player.GetComponent<IguanaController>().GetDamage(2);
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, scarabData.attackRange);
    }
}
