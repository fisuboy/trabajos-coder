using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IguanaController : MonoBehaviour
{
    [SerializeField] private Animator animPlayer;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] GeneralData data;
    [SerializeField] Transform camera;
    public float turnSmoothTime;
    private float turnSmoothVelocity;

    private Rigidbody rbIguana;
    //private float cameraAxisX = 0;
    //private bool isGrounded = true;

    void Start()
    {
        rbIguana = GetComponent<Rigidbody>();
        
    }
    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
            if (IsGrounded())
                Jump();*/
    }

    void FixedUpdate()
    {
        MoveAndRotate();
    }
    
    private void MoveAndRotate()
    {
        /* float xRotate = Input.GetAxis("Horizontal");
         float zMove = Input.GetAxis("Vertical");
         
         cameraAxisX += xRotate;

         Quaternion angulo = Quaternion.Euler(0, cameraAxisX * data.speedTurn, 0);
         transform.rotation = angulo;
         animPlayer.SetFloat("Turn", xRotate);

         if (zMove != 0)
             if (zMove >= 0)
                 rbIguana.AddRelativeForce(Vector3.forward * data.playerSpeed * zMove, ForceMode.Force);
             else
                 rbIguana.AddRelativeForce(Vector3.forward * (data.playerSpeed/2) * zMove, ForceMode.Force);*/
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        //animPlayer.SetFloat("Forward", vertical);
        //animPlayer.SetFloat("Turn", horizontal);
        animPlayer.SetBool("isRun", false);

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            transform.position += moveDir * data.speed * Time.deltaTime;
            //rbIguana.AddRelativeForce(moveDir * data.playerSpeed, ForceMode.Force);
            animPlayer.SetBool("isRun", true);
        }

    }
    /*private void Jump()
    {
        Debug.Log("is jumping");
        rbIguana.AddForce(0, 1 * data.jumpForce, 0);
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Bullet"))
        {
            data.life--;
        }
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
            return true;
        else 
            return false;
    }

    public void GetDamage()
    {
        data.life--;
    }

}
