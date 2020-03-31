using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, Controls.IGameplayActions
{
    [Header("Set in Inspector")]
    public float acceleration;
    public float maxSpeed;
    public float turnMult = 1.0f;
    public float jumpForce;

    [Header("Set Dynamically")] public float speed;
    
    private Rigidbody2D _rb;

    private Animator _animator;
    private static readonly int Speed = Animator.StringToHash("Speed");
    private Collider2D _collider;
    private static readonly int Grounded = Animator.StringToHash("Grounded");
    private float _joyPosX;

    Controls _controls;

    private bool _IsGrounded;
    private bool IsGrounded
    {
        get
        {
            if (_IsGrounded)
            {
                _IsGrounded = false;
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    private int getDirection()
    {
        if (_rb.velocity.x > 0) return 1;
        else if (_rb.velocity.x < 0) return -1;
        else return 0;
    }

    private bool isTurning()
    {
        switch (getDirection())
        {
            case 0:
                return false;
            case 1:
                return Input.GetAxis("Horizontal") < 0;
            case -1:
                return Input.GetAxis("Horizontal") > 0;
            default:
                return false;
        }
    }

    // private bool IsGrounded()
    // {
    //     return Physics.CheckBox(_collider.bounds.center,
    //         new Vector2(_collider.bounds.center.x, _collider.bounds.min.y - 0.1f));
    // }

    private void OnCollisionStay2D(Collision2D other)
    {
        foreach (var contact in other.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
            if (Math.Abs(contact.point.y - _collider.bounds.min.y) < 0.01f) _IsGrounded = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _controls = new Controls();
    }

    private void OnEnable()
    {
        _controls.Gameplay.Movement.performed += OnMovement;
        _controls.Gameplay.Movement.Enable();

        _controls.Gameplay.Jump.performed += OnJump;
        _controls.Gameplay.Jump.Enable();

        _controls.Gameplay.Grapple.performed += OnGrapple;
        _controls.Gameplay.Grapple.Enable();
    }

    private void OnDisable()
    {
        _controls.Gameplay.Movement.performed -= OnMovement;
        _controls.Gameplay.Movement.Disable();

        _controls.Gameplay.Jump.performed -= OnJump;
        _controls.Gameplay.Jump.Disable();

        _controls.Gameplay.Grapple.performed -= OnGrapple;
        _controls.Gameplay.Grapple.Disable();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        // Debug.Log("Move");
        _joyPosX = context.ReadValue<float>();
        // joyPos = _joyPosX;
        // if (isTurning()) deltaX *= Mathf.Max(turnMult, 1);
        // Vector2 movement = new Vector2(deltaX, 0.0f);
        // _rb.AddForce(movement * (acceleration * Time.deltaTime));
    }

    public float JoyPosX => _joyPosX;

    // public float joyPos2;

    public void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log("Jump");
    }

    public void OnGrapple(InputAction.CallbackContext context)
    {
        Debug.Log("Grapple");
    }

    // Update is called once per frame
    void Update()
    {
        // float deltaX = Input.GetAxis("Horizontal");
        float deltaX = _joyPosX;
        if (isTurning()) deltaX *= Mathf.Max(turnMult, 1);
        Vector2 movement = new Vector2(deltaX, 0.0f);
        _rb.AddForce(movement * (acceleration * Time.deltaTime));
        _animator.SetFloat(Speed, Mathf.Abs(_rb.velocity.x));

        // joyPos2 = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded) _rb.AddForce(new Vector2(0.0f, jumpForce));
            else if (_rb.velocity.y > 0) _rb.AddForce(Physics.gravity * (-0.5f * Time.deltaTime));
        }
        
        _animator.SetBool(Grounded, _IsGrounded);
        
        // if (Mathf.Abs(_rb.velocity.x) >= 100)
        // {
        //     
        // }
    }

    private void FixedUpdate()
    {
        speed = _rb.velocity.x;
        if (Mathf.Abs(speed) > maxSpeed)
        {
            Vector2 targetSpeed = new Vector2(maxSpeed, 0.0f);
            _rb.velocity = Vector2.Lerp(new Vector2(speed, 0.0f).normalized, targetSpeed.normalized, 0.05f);
        }
    }
    
    
}
