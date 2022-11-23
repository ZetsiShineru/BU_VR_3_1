using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

public class ChasingPhase : MonoBehaviour
{
    //ตอนไม่ไล่
    void EnemyIdle()
    {
        SoundManager.instance.Play(SoundManager.SoundName.EnemyWalk);
        SoundManager.instance.Loop(SoundManager.SoundName.EnemyWalk);
    }


    //ตอนไล่
    void ChasingStart()
    {
        Random random = new Random();
        int rnd = random.Next(1, 4);
        Debug.Log("rnd");
        
        if (rnd == 1)
            {
                Debug.Log("dia1");
                SoundManager.instance.Play(SoundManager.SoundName.Dialog1);
            }
            else if(rnd == 2)
            {
                Debug.Log("dia2");
                SoundManager.instance.Play(SoundManager.SoundName.Dialog2);
            }
            else if(rnd == 3)
            {
                Debug.Log("dia3");
                SoundManager.instance.Play(SoundManager.SoundName.Dialog3);
            }
            else
            {
                Debug.Log("bug");
            }
            
            SoundManager.instance.Play(SoundManager.SoundName.Chasing);
            SoundManager.instance.Loop(SoundManager.SoundName.Chasing);
            SoundManager.instance.Play(SoundManager.SoundName.EnemyRun);
            SoundManager.instance.Loop(SoundManager.SoundName.EnemyRun);
    }

    //ตอนไล่จบ
    void ChasingEnd()
    {
        SoundManager.instance.Stop(SoundManager.SoundName.Chasing);
        SoundManager.instance.Stop(SoundManager.SoundName.EnemyRun);
        EnemyIdle();
    }

    //ตอนโดนตี
    void Hit()
    {
        Random random = new Random();
        int rnd = random.Next(1, 3);
        if (rnd == 1)
        {
            Debug.Log("hit1");
            SoundManager.instance.Play(SoundManager.SoundName.Hit1);
        }
        else if(rnd == 2)
        {
            Debug.Log("hit2");
            SoundManager.instance.Play(SoundManager.SoundName.Hit2);
        }
    }
    
}

    
    
    

    
