using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotation : MonoBehaviour
{
    private GameObject player;
    [SerializeField] float speedEnemy;
    [SerializeField] private TypesOfEnemy typeMovements;
    enum TypesOfEnemy { Looker, Seeker}

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Fox");
    }

    // Update is called once per frame
    void Update()
    {
        LookAtPlayer(player);
        switch(typeMovements)
        {
            case TypesOfEnemy.Looker:
                LookAtPlayer(player);
                break;
            case TypesOfEnemy.Seeker:
                MoveTowards();
                break;
        }
    }
    private void LookAtPlayer(GameObject lookObject)
    {
        Vector3 direction = lookObject.transform.position - transform.position;
        Quaternion newRotation = Quaternion.LookRotation(direction);
        transform.rotation = newRotation;
    }

    private void MoveTowards()
    {
        Vector3 direction = player.transform.position - transform.position;
        if (direction.magnitude > 10)
        {
            transform.position += speedEnemy * direction.normalized * Time.deltaTime;
        }
    }
}
