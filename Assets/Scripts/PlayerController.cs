using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float mouseMovement;
    [SerializeField] private float playerSpeed;
    [SerializeField] private Animator animPlayer;
    [SerializeField] private float rotationSpeed;
    
    void Start()
    {
        animPlayer.SetBool("run", false);
        animPlayer.SetBool("jump", false);
    }


    void Update()
    {
        //PlayerRotate();
        PlayerMove();
        //PlayerJump();
        //PlayerRotateAndMove();

    }

    private void PlayerMove()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");
        

        if (xMove != 0 || zMove != 0)
        {
            animPlayer.SetBool("run", true);
            transform.forward = Vector3.Lerp(transform.forward, new Vector3(xMove, 0, zMove), rotationSpeed * Time.deltaTime);
            transform.position += playerSpeed * Time.deltaTime * transform.forward;
        }
        else
        {
            animPlayer.SetBool("run", false);
        }
    }

    private void PlayerJump()
    {
        bool pJump = Input.GetKeyDown(KeyCode.Space);
        if (pJump == true)
        {
            animPlayer.SetBool("jump", true);
        }
        else
        {
            animPlayer.SetBool("jump", false);
        }
        
    }

    private void PlayerRotate()
    {
        mouseMovement += Input.GetAxis("Mouse X");
        Quaternion rotation = Quaternion.Euler(0, mouseMovement, 0);
        transform.localRotation = rotation;
    }

    private void PlayerRotateAndMove()
    {
        if (Input.GetKey(KeyCode.W) == true)
        {
            transform.forward = Vector3.Lerp(transform.forward, new Vector3(0, 0, 1), rotationSpeed * Time.deltaTime);
            transform.position += playerSpeed * Time.deltaTime * transform.forward; 
            
        }
        if (Input.GetKey(KeyCode.S) == true)
        {
            transform.forward = Vector3.Lerp(transform.forward, new Vector3(0, 0, -1), rotationSpeed * Time.deltaTime);
            transform.position += playerSpeed * Time.deltaTime * transform.forward;
           
        }
        if (Input.GetKey(KeyCode.D) == true)
        {
            transform.forward = Vector3.Lerp(transform.forward, new Vector3(1, 0, 0), rotationSpeed * Time.deltaTime);
            transform.position += playerSpeed * Time.deltaTime * transform.forward;
           
        }
        if (Input.GetKey(KeyCode.A) == true)
        {
            transform.forward = Vector3.Lerp(transform.forward, new Vector3(-1, 0, 0), rotationSpeed * Time.deltaTime);
            transform.position += playerSpeed * Time.deltaTime * transform.forward;
           
        }
        
    }
}    
