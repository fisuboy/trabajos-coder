using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    [SerializeField] private float xArea;
    [SerializeField] private float zArea;
    [SerializeField] private float timeToChange;
    
    void Start()
    {
        
    }
        
    void Update()
    {
        
    }

    private void MoveToRandomPosition()
    {
        float xIndex = Random.Range(0, xArea);
        float zIndex = Random.Range(0, zArea);
        transform.position = new Vector3(xIndex, 2, zIndex);
    }

    private void GenerateNewOne()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        while (timeToChange > 0)
        {
            timeToChange -= Time.deltaTime;
            Debug.Log(timeToChange);
        }
        MoveToRandomPosition();
        
    }
}
