using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class IguanaController : MonoBehaviour
{
    [SerializeField] private Animator animPlayer;
    [SerializeField] GeneralData data;
    [SerializeField] private float struckForce;
   
    private Rigidbody rbIguana;
    private bool inHighSunZone = false;
    
    //Events
    public static event Action<int> onLifeChange;
    public static event Action onHighSunZoneEnter;
    public static event Action onHighSunZoneExit;

    private void Awake()
    {
        HornAttackController.onHit += OnHitHandler;
        IguanaColorController.onSunHurt += OnSunHurtHandler;
    }
    void Start()
    {
        rbIguana = GetComponent<Rigidbody>();
        data.life = 6;
        onLifeChange?.Invoke(data.life);
        //transform.position = new Vector3(280f, 50f, 38f);
       // Quaternion initialRotation = Quaternion.Euler(0f, -62f, 0);
       // transform.rotation = initialRotation;
    }
    private void Update()
    {
        

        if (inHighSunZone)
            onHighSunZoneEnter?.Invoke();
        else
            onHighSunZoneExit?.Invoke();

        



        //if (Input.GetKey(KeyCode.LeftShift))
        //    SpeedBoost();
        //else
        //    NormalSpeed();
        if (Input.GetKeyDown(KeyCode.B))
        {
            GetDamageStruck();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            data.life--;
            onLifeChange?.Invoke(data.life);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            data.life++;
            onLifeChange?.Invoke(data.life);
        }
    }
   
    private void SpeedBoost()
    {
        data.speed = 550;
        animPlayer.speed = 1.68f;
    }

    private void NormalSpeed()
    {
        data.speed = 275;
        animPlayer.speed = 1;
    }

    private void GetDamageStruck()
    {
        float xIndex = UnityEngine.Random.Range(transform.position.x - 10, transform.position.x + 10);
        //float yIndex = UnityEngine.Random.Range(transform.position.y - 10, transform.position.y);
        float zIndex = UnityEngine.Random.Range(transform.position.z - 10, transform.position.z + 10);
        Vector3 struckInitialPoint = new Vector3(xIndex, transform.position.y, zIndex).normalized;
        Vector3 struckDirection = struckInitialPoint - transform.position;
        rbIguana.AddForce(struckDirection * struckForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Bullet"))
        {
            GetDamage();
        }
        if (collision.gameObject.layer == 10)
        {
            GetDamage();
            Debug.Log("CACTUS DAMAGE");
        }
    }

    public void GetDamage()
    {
        data.life--;
        onLifeChange?.Invoke(data.life);
    }

    public void HighSunZone()
    {
        inHighSunZone = !inHighSunZone;
        Debug.Log(inHighSunZone);
    }

    private void OnHitHandler()
    {
        GetDamage();
    }

    private void OnSunHurtHandler()
    {
        GetDamage();
    }
}
