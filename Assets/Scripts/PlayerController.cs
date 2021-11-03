using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float mouseMovement;
    [SerializeField] float playerSpeed;
<<<<<<< Updated upstream
    [SerializeField] float playerRotation;
    [SerializeField] Vector3 initialPosition;
    
=======
    private bool shrinked = false;
    private float portalTime;
    private float cooldownTime = 0.5f;

>>>>>>> Stashed changes
    void Start()
    {
        transform.position = initialPosition;
    }
    
    
    void Update()
    {
        PlayerRotate();
        PlayerMove();
    }

    private void PlayerMove()
    {
        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");
        transform.Translate(playerSpeed * Time.deltaTime * new Vector3(xMove, 0, zMove));
    }

    private void PlayerRotate()
    {
<<<<<<< Updated upstream
        mouseMovement += Input.GetAxis("Mouse X");
        Quaternion rotation = Quaternion.Euler(0, mouseMovement, 0);
        transform.localRotation = rotation;
=======
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
>>>>>>> Stashed changes
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Player is colliding with " + collision.gameObject.name);
    }
}
