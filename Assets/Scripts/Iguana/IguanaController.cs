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
    [SerializeField] private Transform groundCheck;
    private Rigidbody rbIguana;
    private float turnSmoothTime = .1f;
    private float turnSmoothVelocity;
    private bool inHighSunZone = false;

    //Events
    public static event Action<int> onLifeChange;
    public static event Action onHighSunZoneEnter;
    public static event Action onHighSunZoneExit;

    private void Awake()
    {
        HornAttackController.onHit += OnHitHandler;
    }
    void Start()
    {
        rbIguana = GetComponent<Rigidbody>();
        data.life = 6;
        onLifeChange?.Invoke(data.life);
        transform.position = new Vector3(280f, 50f, 38f);
        Quaternion initialRotation = Quaternion.Euler(0f, -62f, 0);
        transform.rotation = initialRotation;
    }
    private void Update()
    {
        if (IsGrounded() && Input.GetButtonDown("Jump"))
            Jump();

        if (inHighSunZone)
            onHighSunZoneEnter?.Invoke();
        else
            onHighSunZoneExit?.Invoke();

        if (Input.GetKey(KeyCode.LeftShift))
            SpeedBoost();
         
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
    }

    private void SpeedBoost()
    {
        data.speed *= 2;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Bullet"))
        {
            GetDamage();
        }
        if (collision.gameObject.layer == 10)
        {
            GetDamage();
            Debug.Log("CACTUS DAMAGE");
        }
    }

    public void GetDamage()
    {
        data.life--;
        onLifeChange?.Invoke(data.life);
    }

    public void HighSunZone()
    {
        inHighSunZone = !inHighSunZone;
        Debug.Log(inHighSunZone);
    }

    private void OnHitHandler()
    {
        GetDamage();
    }
}
