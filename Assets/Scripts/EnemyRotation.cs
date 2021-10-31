using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotation : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private TypesOfEnemy typeMovements;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float minimunDistance;
    [SerializeField] private float enemySpeed;

    enum TypesOfEnemy { Looker, Seeker }

    void Start()
    {
        player = GameObject.Find("Fox");
    }

    void Update()
    {
        switch (typeMovements)
        {
            case TypesOfEnemy.Looker:
                LookAtPlayer();
                break;
            case TypesOfEnemy.Seeker:
                MoveTowards();
                break;
        }
    }

    void MoveTowards()
    {
        Vector3 direction = player.transform.position - transform.position;
        Quaternion lookAt = Quaternion.LookRotation(direction);
        transform.rotation = lookAt;
        if (direction.magnitude > minimunDistance)
        {
            transform.position += direction.normalized * enemySpeed * Time.deltaTime;
        }
    }

    void LookAtPlayer()
    {
        Quaternion lookAt = Quaternion.LookRotation(player.transform.position - transform.position);
        Quaternion newRotation = Quaternion.Lerp(transform.rotation, lookAt, rotationSpeed * Time.deltaTime);
        transform.rotation = newRotation;
    }
}   
