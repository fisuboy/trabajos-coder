using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogManager : MonoBehaviour
{
    [SerializeField] private GameObject[] logs;
    
    private int arrayIndex = 0;

    void Start()
    {
        logs = new GameObject[8];
    }

    void Update()
    {

    }

    public void AddLog(GameObject log)
    {
        if (arrayIndex < logs.Length)
        {
            logs[arrayIndex] = log;
            arrayIndex++;
        }
        if (arrayIndex == 8)
        {
            Debug.Log("Quest completed");
        }
    }
}
