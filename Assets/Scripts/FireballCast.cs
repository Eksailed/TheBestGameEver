using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCast : MonoBehaviour
{   
    public float damage = 10;


    public Fireball fireballprefab;
    public Transform fireballSourceTransform;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            AudioManager.instance.Play("ShootPlayer");
            var fireball = Instantiate(fireballprefab, fireballSourceTransform.position, fireballSourceTransform.rotation);
            fireball.damage = damage;
        }
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    Cursor.visible = true;
        //}
        //else
        //{
        //    Cursor.lockState = CursorLockMode.Confined;
        //    Cursor.visible = true;
        //}
    }
}
