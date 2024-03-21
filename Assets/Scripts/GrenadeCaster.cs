using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeCaster : MonoBehaviour
{
    public float damage = 50;


    public Rigidbody grenadePrefab;
    public Transform grenadeSourceTransform;
    public Animator animator;

    public float force = 10;

    void Start()
    {
        
    }
    void Update()
    {
        GranadeCast();
    }

    private void GranadeCast()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var grenade = Instantiate(grenadePrefab);
            grenade.transform.position = grenadeSourceTransform.position;
            grenade.GetComponent<Rigidbody>().AddForce(grenadeSourceTransform.forward * force);
            animator.SetBool("Throw granade", true);
            grenade.GetComponent<Grenade>().damage = damage;
        }
        else
        {
            animator.SetBool("Throw granade", false);
        }
    }
}
