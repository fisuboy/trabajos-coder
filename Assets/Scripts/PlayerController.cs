using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float mouseMovement;
    [SerializeField] float playerSpeed;
    [SerializeField] float playerRotation;
    [SerializeField] Vector3 initialPosition;
    
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
        mouseMovement += Input.GetAxis("Mouse X");
        Quaternion rotation = Quaternion.Euler(0, mouseMovement, 0);
        transform.localRotation = rotation;
    }
}
