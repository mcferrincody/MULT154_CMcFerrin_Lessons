using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearBrain : MonoBehaviour
{
    private Bot bot;
    private Vector3 hivePos;
    private bool hiveDropped = false;
    void Start()
    {
        bot = GetComponent<Bot>();
        NavPlayerMovement.DroppedHive += HiveReady;
    }

    void HiveReady(Vector3 pos)
    {
        hivePos = pos;
        hiveDropped = true;
    }
    void Update()
    {
        if (hiveDropped)
        {
            bot.Seek(hivePos);
        }
        else
        {
            if (bot.CanTargetSeeMe())
            {
                bot.Evade();
            }
            else if (bot.CanSeeTarget())
            {
                bot.Persue();
            }
            else
            {
                bot.Wander();
            }
        }
    }
}
