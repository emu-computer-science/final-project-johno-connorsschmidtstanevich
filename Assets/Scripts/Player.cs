using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Set in Inspector")]
    public float acceleration;
    public float maxSpeed;

    [Header("Set Dynamically")] public float speed;
    
    private Rigidbody2D _rb;
    
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
