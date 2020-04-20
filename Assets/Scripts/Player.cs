using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.InputSystem.Controls;

public class Player : MonoBehaviour
{
    [Header("Set in Inspector")]
    public float acceleration;
    public float maxSpeed;
    [FormerlySerializedAs("turnMult")] public float turnMultiplier = 5.0f;
    public float jumpForce;
    
    [Header("Set Dynamically")] public float speed;
    
    private Rigidbody2D _rb;

    private Animator _animator;
    private AnimatorStateInfo _animatorState;
    private Collider2D _collider;
    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int Grounded = Animator.StringToHash("Grounded");
    private static readonly int Taunt = Animator.StringToHash("Taunt");
    private static readonly int Attack = Animator.StringToHash("Attack");
    private float _joyPosX;
    private bool _jumping;
    private PlayerInput _input;
    private SpriteRenderer[] _sprites;

    public SpriteRenderer[] Sprites => _sprites;

    private Camera _playerCam;
    
    private bool _isGrounded;

    public bool IsJumping => _jumping;

    public int HitStun { get; private set; }

    public Vector2 LungeDirection
    {
        get
        {
            return new Vector2(_rb.velocity.x, jumpForce);
        }
    }
    
    /**
     * Checks whether the player is grounded.
     */
    private bool IsGrounded
    {
        get
        {
            if (_isGrounded)
            {
                _isGrounded = false;
                return true;
            }

            return false;
        }
    }

    enum Direction
    {
        LEFT = -1,
        RIGHT = 1,
        NONE = 0
    }

    private Direction Facing
    {
        get
        {
            if (_joyPosX > 0) return Direction.RIGHT;
            if (_joyPosX < 0) return Direction.LEFT;
            return Direction.NONE;
        }
    }
    
    private int GetDirection
    {
        get
        {
            if (_rb.velocity.x > 0) return 1;
            if (_rb.velocity.x < 0) return -1;
            return 0;
        }
    }

    private bool IsTurning
    {
        get
        {
            switch (GetDirection)
            {
                case 0:
                    return false;
                case 1:
                    return _joyPosX < 0;
                case -1:
                    return _joyPosX > 0;
                default:
                    return false;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        foreach (var contact in other.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
            if (Math.Abs(contact.point.y - _collider.bounds.min.y) < 0.01f && contact.normal == Vector2.up) _isGrounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Hitbox") && HitStun <= 0) HitStun = 100;
    }

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _animatorState = _animator.GetCurrentAnimatorStateInfo(0);
        _input = GetComponent<PlayerInput>();
        _sprites = GetComponentsInChildren<SpriteRenderer>();
    }

    private void OnEnable()
    {
        // _controls.Gameplay.Movement.performed += OnMovement;
        // _controls.Gameplay.Movement.Enable();

        // _controls.Gameplay.Jump.performed += OnJump;
        // _controls.Gameplay.Jump.Enable();
        //
        // _controls.Gameplay.Grapple.performed += OnGrapple;
        // _controls.Gameplay.Grapple.Enable();
    }

    private void OnDisable()
    {
        // _controls.Gameplay.Movement.performed -= OnMovement;
        // _controls.Gameplay.Movement.Disable();

        // _controls.Gameplay.Jump.performed -= OnJump;
        // _controls.Gameplay.Jump.Disable();
        //
        // _controls.Gameplay.Grapple.performed -= OnGrapple;
        // _controls.Gameplay.Grapple.Disable();
    }

    public void OnMovement(InputValue context)
    {
        // Debug.Log("Move");
        // _joyPosX = context.Get<float>();
        // joyPos = _joyPosX;
        // if (isTurning()) deltaX *= Mathf.Max(turnMult, 1);
        // Vector2 movement = new Vector2(deltaX, 0.0f);
        // _rb.AddForce(movement * (acceleration * Time.deltaTime));
    }

    public void OnJump(InputValue button)
    {
        Debug.Log("Jump");
        _jumping = button.Get<float>() >= 0.9f;
        if (_jumping && IsGrounded)
        {
            _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    public void OnGrapple(InputValue button)
    {
        Debug.Log("Grapple");
        if(_animatorState.IsName("Idle") || _animatorState.IsName("Running") && button.Get<float>() >= 0.9f) _animator.SetTrigger(Attack);
    }

    public void OnTaunt(InputValue button)
    {
        Debug.Log("Taunt");
        if(_animatorState.IsName("Idle") || _animatorState.IsName("Running") || _animatorState.IsName("Jumping") && button.Get<float>() >= 0.9f) _animator.SetTrigger(Taunt);
    }

    // Update is called once per frame
    private void Update()
    {
        float deltaX = _input.currentActionMap.FindAction("Movement").ReadValue<float>();
        _joyPosX = deltaX;
        if (IsTurning) deltaX *= Mathf.Max(turnMultiplier, 1);
        Vector2 movement = new Vector2(deltaX, 0.0f);
        _rb.AddForce(movement * (acceleration * Time.deltaTime));
    }

    private void LateUpdate()
    {
        _animator.SetFloat(Speed, Mathf.Abs(_rb.velocity.x));
        _animator.SetBool(Grounded, _isGrounded);
        if (Math.Abs(_rb.velocity.y) > 0.05f) _isGrounded = false;
        foreach (var spriteRenderer in _sprites)
        {
            switch (Facing)
            {
                case Direction.LEFT:
                    spriteRenderer.flipX = true;
                    break;
                case Direction.RIGHT:
                    spriteRenderer.flipX = false;
                    break;
            }
        }

        if (HitStun>0) HitStun--;
    }

    private void FixedUpdate()
    {
        speed = _rb.velocity.x;
        if (Mathf.Abs(speed) > maxSpeed)
        {
            Vector2 targetSpeed = new Vector2(maxSpeed, 0.0f);
            _rb.velocity = new Vector2(Vector2.Lerp( new Vector2(speed, 0), GetDirection * targetSpeed, 0.75f).x, _rb.velocity.y);
        }
    }
    
    
}
