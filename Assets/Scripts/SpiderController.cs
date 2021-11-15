using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : MonoBehaviour
{
    [SerializeField] private float speedEnemy = 50f;
    [SerializeField] private float attackRange = 1f;

    private GameObject player;
    private Rigidbody rbSpider;
    private Animator animSpider;

    private bool isAttack = false;

    void Start()
    {
        player = GameObject.Find("Iguana");
        rbSpider = GetComponent<Rigidbody>();
        animSpider = gameObject.transform.GetChild(0).GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        animSpider.SetBool("isAttack", isAttack);
    }

    private void FixedUpdate()
    {
        Vector3 playerDirection = GetPlayerDirection();
        if (playerDirection.magnitude > attackRange)
        {
            isAttack = false;
            rbSpider.rotation = Quaternion.LookRotation(new Vector3(playerDirection.x, 0, playerDirection.z));
            rbSpider.AddForce(playerDirection.normalized * speedEnemy, ForceMode.Impulse);
        }
        else
        {
            isAttack = true;
        }

    }

    private Vector3 GetPlayerDirection()
    {
        return player.transform.position - transform.position;
    }

}