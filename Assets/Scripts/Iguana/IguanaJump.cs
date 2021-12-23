using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IguanaJump : MonoBehaviour
{
    [SerializeField] private GeneralData data;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    private Rigidbody rbIguana;

    void Start()
    {
        rbIguana = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        if (IsGrounded() && Input.GetButtonDown("Jump"))
            Jump();
    }

    private void Jump()
    {
        rbIguana.AddForce(Vector3.up * data.jumpForce, ForceMode.Impulse);
    }

    private bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .2f, groundLayer);
    }
}
