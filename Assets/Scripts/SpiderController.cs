using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float lerpSpeed;
    [SerializeField] private float chaseSpeed;
    [SerializeField] private float visionRange;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] private float jumpForce;
    [SerializeField] private float minimumDistance;

    private bool inRange = false;
    private Rigidbody rbSpider;
    

    void Start()
    {
        rbSpider = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= visionRange)
            inRange = true;
        else
            inRange = false;

        if (inRange)
        {
            if (DistanceToPlayer().magnitude >= minimumDistance)
            {
                ChasePlayer();
                if (IsGrounded())
                    Jump();
            }
        }
    }
    
    private void ChasePlayer()
    {
        transform.forward = Vector3.Lerp(transform.forward, DistanceToPlayer().normalized, lerpSpeed * Time.deltaTime);
        transform.position += transform.forward * chaseSpeed * Time.deltaTime;
    }

    private void Jump()
    {
        Debug.Log("is jumping");
        rbSpider.AddForce(0, 1 * jumpForce, 0);
    }

    private Vector3 DistanceToPlayer()
    {
        Vector3 distance = player.transform.position - transform.position;
        return distance;
    }

    private bool IsGrounded()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 0.5f, groundLayer))
            return true;
        else
            return false;
    }

    private void OnDrawGizmos()
    {
        if (inRange)
            Gizmos.color = Color.red;

        else
            Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position, visionRange);
    }
}
