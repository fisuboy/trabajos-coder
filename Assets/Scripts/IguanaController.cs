using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IguanaController : MonoBehaviour
{
    [SerializeField] private int life;
    [SerializeField] private float cameraAxisX;
    [SerializeField] private float playerSpeed;
    [SerializeField] private Animator animPlayer;
    [SerializeField] private float speedTurn;
    [SerializeField] private float jumpForce;
    private Rigidbody rbIguana;
    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rbIguana = transform.GetComponent<Rigidbody>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                Jump();
            }
            
        }

    }
    void FixedUpdate()
    {
        MoveAndRotate();
        
    }
    
    private void MoveAndRotate()
    {
        float xRotate = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");
        animPlayer.SetFloat("Forward", zMove);
        cameraAxisX += xRotate;

        Quaternion angulo = Quaternion.Euler(0, cameraAxisX * speedTurn, 0);
        transform.rotation = angulo;
        animPlayer.SetFloat("Turn", xRotate);

        if (zMove != 0)
        {
            if (zMove >= 0)
            {
                rbIguana.AddRelativeForce(Vector3.forward * playerSpeed * zMove, ForceMode.Force);
                
            }
            else
            {
                rbIguana.AddRelativeForce(Vector3.forward * (playerSpeed/2) * zMove, ForceMode.Force);
            }
        }
    }

    private void Jump()
    {
        Debug.Log("is jumping"); 
        rb.AddForce(0, 1 * jumpForce, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            isGrounded = true;
        }
        if(other.gameObject.layer == 10)
        {
            GetDamage();
            Debug.Log("CACTUS DAMAGE");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            isGrounded = false;
        }
    }

   

    public void GetDamage()
    {
        life--;
    }
}
