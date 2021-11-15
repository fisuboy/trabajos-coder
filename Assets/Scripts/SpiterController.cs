using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiterController : MonoBehaviour
{

    [SerializeField] private int spiterLife;
    [SerializeField] private float visionRange;
    [SerializeField] private float lerpSpeed;
    [SerializeField] private int shootCooldown;
    [SerializeField] private int changeCooldown;
    [SerializeField] private float shootForce;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject shootOrigen;
    [SerializeField] private Transform[] spawns;

    private float timeToShoot = 0f;
    private float timeToChange = 0f;
    private bool canShoot = false;
    private bool canChange = false;
    private bool playerInRange = false;

    void Start()
    {
        transform.position = new Vector3(transform.position.x, 9f, transform.position.z);
    }

    void Update()
    {
        DestroySpiter();
        if (Vector3.Distance(transform.position, player.transform.position) <= visionRange)
            playerInRange = true;
        
        else
            playerInRange = false;
        

        if (playerInRange)
        {
            Emerge();
            LookAtPlayer();
            timeToChange = 0;
            
            if (canShoot)
                Shoot();
            
            else
                timeToShoot += Time.deltaTime;
            
            if (timeToShoot > shootCooldown)
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

            if (timeToChange >= changeCooldown)
                canChange = true;

        }
    }

    private void Shoot()
    {
        canShoot = false;
        timeToShoot = 0;
        Vector3 playerDirection = player.transform.position - transform.position;
        GameObject bulletInstantiate = Instantiate(bullet, shootOrigen.transform.position, transform.rotation);
        bulletInstantiate.GetComponent<Rigidbody>().AddForce(playerDirection.normalized * shootForce, ForceMode.Impulse);
    }

    private void LookAtPlayer()
    {
        Vector3 playerDirection = player.transform.position - transform.position;
        Quaternion lookAt = Quaternion.LookRotation(playerDirection);
        Quaternion newRotation = Quaternion.Lerp(transform.rotation, lookAt, lerpSpeed * Time.deltaTime);
        transform.rotation = newRotation;
    }

    public void GetHit(bool hit)
    {
        if (hit)
            spiterLife--;
    }

    private void DestroySpiter()
    {
        if (spiterLife == 0)
            Destroy(gameObject);
    }

    private void Emerge()
    {
        transform.position = new Vector3(transform.position.x, 10.5f, transform.position.z);
    }

    private void Sumerge()
    {
        transform.position = new Vector3(transform.position.x, 9f, transform.position.z);
    }

    private void ChangePosition()
    {
        int index = Random.Range(0, spawns.Length);
        transform.position = spawns[index].transform.position;
    }

    private void OnDrawGizmos()
    {
        if (playerInRange)
            Gizmos.color = Color.red;
        
        else
            Gizmos.color = Color.green;
        
        Gizmos.DrawWireSphere(transform.position, visionRange);
    }
}
