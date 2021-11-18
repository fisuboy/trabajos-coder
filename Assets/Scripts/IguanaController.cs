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
    [SerializeField] LayerMask groundLayer;
    private Rigidbody rbIguana;
    private bool isGrounded = true;

    void Start()
    {
        rbIguana = transform.GetComponent<Rigidbody>();
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded())
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
        float xRotate = Input.GetAxis("Horizontal");
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
        rbIguana.AddForce(0, 1 * jumpForce, 0);
    }

    private void OnTriggerEnter(Collider other)
    //hacer esto con switch para distintos layers
    {
        /*if (other.gameObject.layer == 6)
        {
            isGrounded = true;
        }*/
        if (other.gameObject.layer == 10)
        {
            GetDamage();
            Debug.Log("CACTUS DAMAGE");
        }
        if (other.gameObject.layer == 9)
        {
            GameManager.instance.AddScore();
            Debug.Log("HIT ENEMY Score is: " + GameManager.GetScore());
        }
    }
    /*private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            isGrounded = false;
        }
    }*/
    private bool IsGrounded()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 0.5f, groundLayer))
        {
            return true;
        }
        else return false;
    }

    public void GetDamage()
    {
        life--;
    }

}
