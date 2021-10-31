using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Controller : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float minimunDistance;
    [SerializeField] private float enemySpeed;
     
    void Start()
    {
        player = GameObject.Find("Fox");
    }

    
    void Update()
    {
        MoveTowards();
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
}
