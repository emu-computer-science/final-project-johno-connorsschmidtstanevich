using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Set in Inspector")]
    public float acceleration;
    public float maxSpeed;
    public float turnMult = 1.0f;

    [Header("Set Dynamically")] public float speed;
    
    private Rigidbody2D _rb;

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
            break;
            case 1:
                return Input.GetAxis("Horizontal") < 0;
            break;
            case -1:
                return Input.GetAxis("Horizontal") > 0;
            break;
            default:
                return false;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal");
        if (isTurning()) deltaX *= Mathf.Max(turnMult, 1);
        Vector2 movement = new Vector2(deltaX, 0.0f);
        _rb.AddForce(movement * acceleration);
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
