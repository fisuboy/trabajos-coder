using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class IguanaColorController : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer iguanaSMR;
    [SerializeField] private float lerpTime;
    [SerializeField] private Color burnColor;
    [SerializeField] private Color normalColor;
    private float hurtCooldown = 2f;
    private float timeToHurt = 0f;
    private bool canHurt = true;

    public static Action onSunHurt;

    private void Update()
    {
        if (iguanaSMR.material.color.r <= 0.7f && canHurt)            
             SunHurt();
        else
            timeToHurt += Time.deltaTime;

        if (timeToHurt >= hurtCooldown)
            canHurt = true;
    }
    public void HeatUp(Color color)
    {
        iguanaSMR.material.color = Color.Lerp(color, burnColor, lerpTime);
    }

    public void HeatDown(Color color)
    {
        iguanaSMR.material.color = Color.Lerp(color, normalColor, lerpTime);
    }

    private void SunHurt()
    {
        onSunHurt?.Invoke();
        timeToHurt = 0;
        canHurt = false;
    }
}
