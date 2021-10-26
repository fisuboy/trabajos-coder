using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    [SerializeField] Vector3 initialPosition;

    void Start()
    {
        transform.position = initialPosition;
    }
    
    
    void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");
        transform.Translate(playerSpeed * Time.deltaTime * new Vector3(xMove, 0, zMove));
    }
}
