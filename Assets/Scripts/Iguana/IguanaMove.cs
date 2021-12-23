using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IguanaMove : MonoBehaviour
{
    [SerializeField] private GeneralData data;
    [SerializeField] private Transform _camera;
    private Animator animPlayer;
    private float turnSmoothTime = .1f;
    private float turnSmoothVelocity;

    void Start()
    {
        animPlayer = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        MoveAndRotate();
    }

    private void MoveAndRotate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        animPlayer.SetBool("isRun", false);

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            //rbIguana.AddForce(moveDir * data.speed, ForceMode.Force);
            transform.position += moveDir * data.speed * Time.deltaTime;
            animPlayer.SetBool("isRun", true);
        }
    }
}
