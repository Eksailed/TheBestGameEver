using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassDoor : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("character_nearby", true);
    }
    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("character_nearby", false);
    }
}
