using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCinematicMovement : MonoBehaviour
{
    [SerializeField] private Transform refence;
    [SerializeField] private float speed;
    private float turnSmoothVelocity;
    private float turnSmoothTime = 0.1f;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.T))
            Debug.Log("T");
            AngularMovement();
    }

    private void AngularMovement()
    {
        Vector3 direction = (refence.position - transform.position).normalized;
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
        transform.position += transform.right * speed * Time.deltaTime;
    }
}
