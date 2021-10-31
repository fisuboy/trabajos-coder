using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    private bool shrinked = false;

    void Start()
    {

    }

    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");
        transform.Translate(playerSpeed * Time.deltaTime * new Vector3(xMove, 0, zMove));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (shrinked == false)
        {
            transform.localScale /= 2;
            shrinked = true;
        }
    }
}
