using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float gravity = 9.8f;
    public float speed;
    public float jumpForce;
    
    
    private float _fallVelocity = 0;
    private CharacterController _characterController;
    private Vector3 _moveVector;
    

    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        //MOVE
        _moveVector = Vector3.zero;
        animator.SetFloat("speed", 0);

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
            animator.SetFloat("speed", 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
            animator.SetFloat("speed", -1);
;        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 4;
        }
        else
        {
            speed = 2;
        }

        //JUMP
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -jumpForce;
            animator.SetBool("IsGrounded", false);
        }
        
    }


    void FixedUpdate()
    {
        //MOVE
        _characterController.Move(_moveVector * speed * Time.fixedDeltaTime);

        //JUMP
        _fallVelocity += gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);

        //Stop fall on ground
        if (_characterController.isGrounded)
        {
            animator.SetBool("IsGrounded", true);
            _fallVelocity = 0;
            
        }
    }
}
