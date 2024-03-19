using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public float value = 100;

    public Animator zombieanimator;
    //public Animator zombieanimator2;

    public void DealDamage(float damage)
    {
        value -= damage;
        if (value <= 0)
        {
            EnemyDeath();
            //Destroy(gameObject);
        }
        else
        {
            zombieanimator.SetTrigger("hit");
            //zombieanimator2.SetTrigger("hit");
        }
    }

    private void EnemyDeath()
    {
        zombieanimator.SetTrigger("death");
        //zombieanimator2.SetTrigger("death");
        GetComponent<EnemyAI>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
    }
}
