using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EagleTwigQuest : MonoBehaviour
{
    public static event Action onQuestComplete;
    private int twigs;

    private void Awake()
    {
        LogEvent.onPickUp += onPickUpHandler;
    }

    private void Start()
    {
        twigs = 0;
    }

    private void Update()
    {
      if (twigs == 8)
        {
            onQuestComplete?.Invoke();
        }  
    }

    private void onPickUpHandler()
    {
        twigs++;
    }
}
