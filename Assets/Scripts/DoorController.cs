using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Animator animDoor;

    void Start()
    {
        animDoor = this.transform.parent.GetComponent<Animator>(); 
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        animDoor.SetBool("isOpening", true);
    }

    private void OnTriggerExit(Collider other)
    {
        animDoor.SetBool("isOpening", false);
    }
}
