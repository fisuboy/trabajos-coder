using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float speedBala = 5.0f;
    public int damage;
    public Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("EN EL FRAME INICIAL ENEMY...");
        Debug.DrawLine(transform.position, new Vector3(5, 0, 0), Color.red, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(speedEnemy * Vector3.right * Time.deltaTime);
        //transform.position += new Vector3(speedEnemy, 0, 0) * Time.deltaTime;
        //transform.Translate(speedEnemy * Time.deltaTime * Vector3.right);
        MoveBala();
    }

    private void MoveBala()
    {
        transform.Translate(speedBala * Time.deltaTime * direction);
    }
}