using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IguanaColorController : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer iguanaSMR;
    [SerializeField] private float lerpTime;
    [SerializeField] private Color burnColor;
    [SerializeField] private Color normalColor;

    public void HeatUp(Color color)
    {
        iguanaSMR.material.color = Color.Lerp(color, burnColor, lerpTime);
    }

    public void HeatDown(Color color)
    {
        iguanaSMR.material.color = Color.Lerp(color, normalColor, lerpTime);
    }


}
