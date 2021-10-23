using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speedBala = 5.0f;
    public int damage;
    public Vector3 direction;
    public float liveBullet;

    void Start()
    {
        Debug.Log("EN EL FRAME INICIAL ENEMY...");
        Debug.DrawLine(transform.position, new Vector3(5, 0, 0), Color.red, 5f);
    }

    void Update()
    {
        //Debug.Log(speedEnemy * Vector3.right * Time.deltaTime);
        //transform.position += new Vector3(speedEnemy, 0, 0) * Time.deltaTime;
        //transform.Translate(speedEnemy * Time.deltaTime * Vector3.right);
        MoveBala();
        liveBullet -= Time.deltaTime;
        if (liveBullet < 0)
        {
            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            DuplicateScale();
        }
    }

    private void MoveBala()
    {
        transform.Translate(speedBala * Time.deltaTime * direction);
    }

    private void DuplicateScale()
    {
        this.transform.localScale *= 2;
    }
}