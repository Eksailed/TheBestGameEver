using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float gravity = 9.8f;
    public float speed;
    public float jumpForce;

    public Transform Gun;

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
        MoveUpdate();

        //JUMP
        JumpUpdate();

    }
    private void MoveUpdate()
    {
        _moveVector = Vector3.zero;
        var runDirection = 0;
        Gun.gameObject.SetActive(false);

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
            runDirection = 1;
            Gun.gameObject.SetActive(true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
            runDirection = 2;
            Gun.gameObject.SetActive(true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
            runDirection = 3;
            Gun.gameObject.SetActive(true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
            runDirection = 4;
            Gun.gameObject.SetActive(true);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 4;
            Gun.gameObject.SetActive(true);
        }
        else
        {
            speed = 2;
            Gun.gameObject.SetActive(true);
        }

        animator.SetInteger("run direction", runDirection);
    }


    private void JumpUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -jumpForce;
            //animator.SetBool("IsGrounded", false);
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
        //if (_characterController.isGrounded)
        //{
        //    animator.SetBool("IsGrounded", true);
        //    _fallVelocity = 0;
            
        //}
    }
}
