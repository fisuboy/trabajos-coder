using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : MonoBehaviour
{
    private Rigidbody rbSpider;
    private float jumpForce = 1;
    [SerializeField] private GameObject player;
    [SerializeField] private float lerpSpeed;
    [SerializeField] private float chaseSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }
    private void ChasePlayer()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        transform.forward = Vector3.Lerp(transform.forward, direction, lerpSpeed * Time.deltaTime);
        transform.position += transform.forward * chaseSpeed * Time.deltaTime;
    }
    private void Jump()
    {
        Debug.Log("is jumping");
        rbSpider.AddForce(0, 1 * jumpForce, 0);
    }
}
