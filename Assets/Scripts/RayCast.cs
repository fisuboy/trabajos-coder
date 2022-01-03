using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    [SerializeField]
    private LayerMask ignoredLayers;
    //[SerializeField]
    //private Camera thirdPersonCamera;
    //[SerializeField]
    //private Transform lookOrigin;
    [SerializeField]
    private float range;


    public GameObject handPoint;
    private bool boolSoltar;
    private GameObject obj;

    private void Start()
    {
        boolSoltar = false;
    }

    void Update()

    {
        if (Input.GetKeyDown(KeyCode.E) && boolSoltar == false)
        {
            RaycastHit hit;
            bool isColliding = Physics.Raycast(transform.position, transform.forward, out hit, range, ignoredLayers);
            
            

            if (isColliding && hit.transform.GetComponent<Rigidbody>())
            {
                Debug.Log("Entro");

                obj = hit.transform.gameObject;

                obj.GetComponent<Rigidbody>().useGravity = false;

                obj.GetComponent<Rigidbody>().isKinematic = true;

                obj.transform.position = handPoint.transform.position;

                obj.transform.SetParent(handPoint.gameObject.transform);

                boolSoltar = true;
            }
        }

        else if (Input.GetKeyDown("e") && boolSoltar)
        {
            obj.GetComponent<Rigidbody>().useGravity = true;

            obj.GetComponent<Rigidbody>().isKinematic = false;

            obj.transform.SetParent(null);

            boolSoltar = false;
        }
    }
}
