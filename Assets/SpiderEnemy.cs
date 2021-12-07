using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderEnemy : Enemies
{
    
    
    private void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= data.visionRange)
            inRange = true;
        else
            inRange = false;

        if (inRange)
        {
            anim.SetBool("isRun", true);
            MoveToTarget(player, data.speed);
        }
        else
        {
            anim.SetBool("isRun", false);
        }

    }
}
