using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class Player : MonoBehaviour, Controls.IGameplayActions
{
    [Header("Set in Inspector")]
    public float acceleration;
    public float maxSpeed;
    [FormerlySerializedAs("turnMult")] public float turnMultiplier = 5.0f;
    public float jumpForce;
    public Camera playerCamPrefab;
    
    [Header("Set Dynamically")] public float speed;
    
    private Rigidbody2D _rb;

    private Animator _animator;
    private static readonly int Speed = Animator.StringToHash("Speed");
    private Collider2D _collider;
    private static readonly int Grounded = Animator.StringToHash("Grounded");
    private float _joyPosX;
    private bool _jumping;
    [SerializeField] List<Collider2D> groundTouched = new List<Collider2D>();

    Controls _controls;

    private Camera _playerCam;
    

    private bool _isGrounded;

    public bool IsJumping => _jumping;

    /**
     * Checks whether the player is grounded.
     */
    // public bool IsGrounded
    // {
    //     get
    //     {
    //         var contacts = new List<ContactPoint2D>();
    //         foreach (var point in groundTouched)
    //         {
    //             point.GetContacts(contacts);
    //             foreach (var VARIABLE in contacts)
    //             {
    //                 if (VARIABLE.normal == Vector2.down) return true;
    //             }
    //         }
    //         return false;
    //     }
    // }

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

    private int GetDirection
    {
        get{
            if (_rb.velocity.x > 0) return 1;
            if (_rb.velocity.x < 0) return -1;
            return 0;}
        
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
                    return Input.GetAxis("Horizontal") < 0;
                case -1:
                    return Input.GetAxis("Horizontal") > 0;
                default:
                    return false;
            }
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
            if (Math.Abs(contact.point.y - _collider.bounds.min.y) < 0.01f && contact.normal == Vector2.up) _isGrounded = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        List<ContactPoint2D> points = new List<ContactPoint2D>();
        other.GetContacts(points);
        foreach (var point in points)
        {
            if (point.normal == Vector2.up && !groundTouched.Contains(other.collider) && point.otherCollider.Equals(_collider))
            {
                groundTouched.Add(other.collider);
                // return;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (groundTouched.Contains(other.collider))
        {
            groundTouched.Remove(other.collider);
        }
    }

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _controls = new Controls();
        _playerCam = Instantiate(playerCamPrefab);
        _playerCam.GetComponent<CameraController>().player = gameObject;
        GetComponent<PlayerInput>().camera = _playerCam;
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

    [FormerlySerializedAs("JoyPosX")] public float joyPosX;

    // public float joyPos2;

    public void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log("Jump");
        _jumping = context.ReadValue<float>() >= 0.9f;
        if (_jumping && IsGrounded)
        {
            _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            debugJumpHold = 0.0f;
        }
    }

    public void OnGrapple(InputAction.CallbackContext context)
    {
        Debug.Log("Grapple");
    }

    public bool debugJump;
    public float debugJumpHold = 0.0f;
    public bool debugIsGrounded;

    private void DebugUpdater()
    {
        joyPosX = _joyPosX;
        debugJump = _jumping;
        debugIsGrounded = _isGrounded;
    }

    // Update is called once per frame
    private void Update()
    {
        // float deltaX = Input.GetAxis("Horizontal");
        float deltaX = _joyPosX;
        if (IsTurning) deltaX *= Mathf.Max(turnMultiplier, 1);
        Vector2 movement = new Vector2(deltaX, 0.0f);
        _rb.AddForce(movement * (acceleration * Time.deltaTime));
        

        // joyPos2 = Input.GetAxis("Horizontal");
        // if(_controls.Gameplay.Jump.)
        // if (_jumping)
        // {
        //     if (_rb.velocity.y > 0)
        //     {
        //         _rb.AddForce(Physics2D.gravity * (_rb.gravityScale * -0.25f));
        //         debugJumpHold += Time.deltaTime;
        //     }
        // }

        
        // if (Mathf.Abs(_rb.velocity.x) >= 100)
        // {
        //     
        // }
    }

    private void LateUpdate()
    {
        DebugUpdater();
        _animator.SetFloat(Speed, Mathf.Abs(_rb.velocity.x));
        _animator.SetBool(Grounded, _isGrounded);
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
