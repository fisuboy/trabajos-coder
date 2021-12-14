using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderGenerator : MonoBehaviour
{
    
    enum EnemyTypes { Small = 1, Big };
    [SerializeField] private EnemyTypes type;
    [SerializeField] private GameObject spider;

    private void Start()
    {
        switch (type)
        {
            case EnemyTypes.Small:
                GameObject a = Instantiate(spider, transform.position, transform.rotation);
                a.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                Quaternion rotationA = Quaternion.Euler(0, 90, 0);
                a.transform.rotation = rotationA;
                break;
            case EnemyTypes.Big:
                GameObject b = Instantiate(spider, transform.position, transform.rotation);
                Quaternion rotationB = Quaternion.Euler(0, 90, 0);
                b.transform.rotation = rotationB;
                break;
            default:
                Debug.Log("<color=#FF0000>ERROR AL ELEGIR NIVEL</color>");
                break;
        }
    }
}

