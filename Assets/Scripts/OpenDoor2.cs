using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor2 : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
