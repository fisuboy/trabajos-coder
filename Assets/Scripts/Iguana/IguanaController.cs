using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class IguanaController : MonoBehaviour
{
    [SerializeField] private IguanaData iguanaData;
    private Animator animPlayer;
    private bool inHighSunZone = false;
    
    //Events
    public static event Action<int> onLifeChange;
    public static event Action onHighSunZoneEnter;
    public static event Action onSafeZoneEnter;

    private void Awake()
    {
        IguanaColorController.onSunHurt += OnSunHurtHandler;
        EagleAttack.onPlayerAttacked += OnPlayerAttackedHandler;
    }

    void Start()
    {
        animPlayer = GetComponent<Animator>();
        iguanaData.life = 6;
        Debug.Log(iguanaData.life);
        onLifeChange?.Invoke(iguanaData.life);
        //transform.position = new Vector3(93.37f, 30.08f, 566.93f);
        //Quaternion initialRotation = Quaternion.Euler(0f, 416.233f, 0);
        //transform.rotation = initialRotation;
    }
    private void Update()
    {
        if (inHighSunZone)
            onHighSunZoneEnter?.Invoke();
        else
            onSafeZoneEnter?.Invoke();
      
        if (Input.GetKeyDown(KeyCode.M))
        {
            iguanaData.life++;
            onLifeChange?.Invoke(iguanaData.life);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            iguanaData.life--;
            onLifeChange?.Invoke(iguanaData.life);
        }
    }
    
    public void GetDamage(int damage)
    {
        iguanaData.life -= damage;
        onLifeChange?.Invoke(iguanaData.life);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10)
            GetDamage(1);
    }

    public void HighSunZone()
    {
        inHighSunZone = !inHighSunZone;
        //Debug.Log(inHighSunZone);
    }

    private void OnSunHurtHandler()
    {
        GetDamage(1);
    }

    private void OnPlayerAttackedHandler()
    {
        GetDamage(1);
    }

    private void OnDestroy()
    {
        IguanaColorController.onSunHurt -= OnSunHurtHandler;
        EagleAttack.onPlayerAttacked -= OnPlayerAttackedHandler;
    }
}
