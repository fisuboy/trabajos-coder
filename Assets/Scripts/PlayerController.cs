using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    private bool shrinked = false;
    private float portalTime;
    private float cooldownTime = 0.5f;

    void Start()
    {

    }

    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");
        transform.Translate(playerSpeed * Time.deltaTime * new Vector3(xMove, 0, zMove));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Time.time > portalTime)
        {
            if (shrinked == false)
            {
                transform.localScale /= 2;
                shrinked = true;
                portalTime = Time.time + cooldownTime;

            }
            else
            {
                transform.localScale *= 2;
                shrinked = false;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Player is colliding with " + collision.gameObject.name);
    }
}
