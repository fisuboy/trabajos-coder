using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScarabEnemie : Enemies
{
    [SerializeField] Transform waypoint;
    [SerializeField] Transform reference;
    [SerializeField] ScarabSpecificData scarabData;
    private float xIndex;
    private float zIndex;
    private bool canChange = false;
    private float timeToChange = 0f;

    private void CreateNewWay()
    {
        if (Vector3.Distance(transform.position, waypoint.transform.position) <= 0.2f)
        {
            timeToChange = 0;
            xIndex = Random.Range((reference.transform.position.x - (scarabData.xArea / 2)), (reference.transform.position.x + (scarabData.xArea / 2)));
            zIndex = Random.Range((reference.transform.position.z - (scarabData.zArea / 2)), (reference.transform.position.z + (scarabData.zArea / 2)));
            waypoint.transform.position = new Vector3(xIndex, waypoint.transform.position.y, zIndex);
        }

        if (canChange)
        {
            canChange = false;
            timeToChange = 0;
            xIndex = Random.Range((reference.transform.position.x - (scarabData.xArea / 2)), (reference.transform.position.x + (scarabData.xArea / 2)));
            zIndex = Random.Range((reference.transform.position.z - (scarabData.zArea / 2)), (reference.transform.position.z + (scarabData.zArea / 2)));
            waypoint.transform.position = new Vector3(xIndex, waypoint.transform.position.y, zIndex);
        }
        else
            timeToChange += Time.deltaTime;


        if (timeToChange >= scarabData.changeCooldown)
            canChange = true;
    }

    
}
