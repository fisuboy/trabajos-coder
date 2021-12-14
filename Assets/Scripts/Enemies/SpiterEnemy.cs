using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiterEnemy : Enemies
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject shootOrigen;
    [SerializeField] private Transform[] spawns;
    [SerializeField] private SpiterSpecificData spiterData;
    private float timeToShoot = 0f;
    private float timeToChange = 0f;
    private bool canShoot = false;
    private bool canChange = false;
        
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= data.visionRange)
            inRange = true;
        else
            inRange = false;

        if (inRange)
        {
            Emerge();
            LookAtPlayer();
            timeToChange = 0;

            if (canShoot)
            {
                anim.SetTrigger("Attack");
                AttackPlayer();
            }


            else
                timeToShoot += Time.deltaTime;

            if (timeToShoot > spiterData.shootCooldown)
                canShoot = true;
        }
        else
        {
            timeToShoot = 0;
            Sumerge();

            if (canChange)
            {
                canChange = false;
                timeToChange = 0;
                ChangePosition();
            }
            else
                timeToChange += Time.deltaTime;

            if (timeToChange >= spiterData.changeCooldown)
                canChange = true;
        }
    }

    protected override void AttackPlayer()
    {
        canShoot = false;
        timeToShoot = 0;
        Vector3 playerDirection = (player.transform.position - transform.position).normalized;
        Vector3 fixedPlayerDirection = new Vector3(playerDirection.x, playerDirection.y - spiterData.shootFix, playerDirection.z);
        GameObject bulletInstantiate = Instantiate(bullet, shootOrigen.transform.position, transform.rotation);
        bulletInstantiate.GetComponent<Rigidbody>().AddForce(fixedPlayerDirection * spiterData.shootForce, ForceMode.Impulse);
    }

    private void LookAtPlayer()
    {
        Vector3 playerDirection = player.transform.position - transform.position;
        Quaternion lookAt = Quaternion.LookRotation(playerDirection);
        Quaternion newRotation = Quaternion.Lerp(transform.rotation, lookAt, spiterData.lerpSpeed * Time.deltaTime);
        transform.rotation = newRotation;
    }

    private void Emerge()
    {
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }

    private void Sumerge()
    {
        transform.position = new Vector3(transform.position.x, -46.9f, transform.position.z);
    }

    private void ChangePosition()
    {
        int index = Random.Range(0, spawns.Length);
        transform.position = spawns[index].transform.position;
    }
}
