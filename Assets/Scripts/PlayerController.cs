using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    [SerializeField] float playerRotation;
    [SerializeField] Vector3 initialPosition;

    void Start()
    {
        transform.position = initialPosition;
    }
    
    
    void Update()
    {
        PlayerMove();
        PlayerRotate();
    }

    private void PlayerMove()
    {
        //float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");
        transform.Translate(playerSpeed * Time.deltaTime * new Vector3(0, 0, zMove));
    }

    private void PlayerRotate()
    {
        float xMove = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, xMove * playerRotation * Time.deltaTime);
    }
}
