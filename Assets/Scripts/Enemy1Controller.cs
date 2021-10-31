using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Controller : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float rotationSpeed;

    void Start()
    {
        player = GameObject.Find("Fox");
    }

    
    void Update()
    {
        LookAtPlayer();
    }

    void LookAtPlayer()
    {
        Quaternion lookAt = Quaternion.LookRotation(player.transform.position - transform.position);
        Quaternion newRotation = Quaternion.Lerp(transform.rotation, lookAt, rotationSpeed * Time.deltaTime);
        transform.rotation = newRotation;
    }
}
