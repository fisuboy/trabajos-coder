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
    private Rigidbody rbIguana;

    void Start()
    {
        rbIguana = transform.GetComponent<Rigidbody>();
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

        if (zMove != 0)
        {
            if (zMove >= 0)
            {
                rbIguana.AddRelativeForce(Vector3.forward * playerSpeed * zMove, ForceMode.Force);
                if (xRotate != 0)
                {
                    
                }
            }
            else
            {
                rbIguana.AddRelativeForce(Vector3.forward * (playerSpeed/2) * zMove, ForceMode.Force);
            }
            
            Quaternion angulo = Quaternion.Euler(0, cameraAxisX * speedTurn, 0);
            transform.rotation = angulo;
            animPlayer.SetFloat("Turn", xRotate);
        }
    }

    public void GetDamage()
    {
        life--;
    }
}
