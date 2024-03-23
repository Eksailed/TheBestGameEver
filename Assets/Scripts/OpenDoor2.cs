using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor2 : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        
    }

    void Update()
    {
        //if (Input.GetKey(KeyCode.E))
        //{
        //    animator.SetBool("character_nearby", true);
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("character_nearby", true);
    }
    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("character_nearby", false);  
    }
}
