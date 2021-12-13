using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class IguanaController : MonoBehaviour
{
    [SerializeField] private Animator animPlayer;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] GeneralData data;
    [SerializeField] Transform _camera;
    [SerializeField] private float raycastLarge;
    [SerializeField] private float turnSmoothTime;
    [SerializeField] private Transform groundCheck;
    private float turnSmoothVelocity;
    //private bool isGrounded = true;

    private Rigidbody rbIguana;
    private SphereCollider col;
    public static event Action<int> onLifeChange;
    
    private void Awake()
    {
        ScarabEnemy.onHit += OnHitHandler;
        EagleTwigQuest.onQuestComplete += OnQuestCompleteHandler;
    }
    void Start()
    {
        rbIguana = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();
        data.life = 6;
        onLifeChange?.Invoke(data.life);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            data.life--;
            onLifeChange?.Invoke(data.life);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            data.life++;
            onLifeChange?.Invoke(data.life);
        }
    }

    void FixedUpdate()
    {
        if (IsGrounded() && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        MoveAndRotate();
    }
    
    private void MoveAndRotate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        animPlayer.SetBool("isRun", false);

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            rbIguana.AddForce(moveDir * data.speed, ForceMode.Force);
            animPlayer.SetBool("isRun", true);
        }
    }
    private void Jump()
    {
        rbIguana.AddForce(Vector3.up * data.jumpForce, ForceMode.Impulse);
    }

    private bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, groundLayer);      
        //return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayer);
    }

   private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Bullet"))
        {
            GetDamage();
        }
    }

    private void OnTriggerEnter(Collider other)
    //hacer esto con switch para distintos layers
    {
        //if (other.gameObject.layer == 6)
       // {
        //    isGrounded = true;
       // }
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
   

    public void GetDamage()
    {
        data.life--;
        onLifeChange?.Invoke(data.life);
    }

    private void OnHitHandler()
    {
        GetDamage();
    }

    private void OnQuestCompleteHandler()
    {
        Debug.Log("Quest Complete");
    }
}
