using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpPhysics : MonoBehaviour
{
        [Header("Set in Inspector")]
        public float fallMultiplier;
        public float lowJumpMultiplier;
        
        private Rigidbody2D _rb;
        private Player _player;
        private PlayerInput _input;

        private bool Jumping => _input.currentActionMap.FindAction("Jump").ReadValue<float>() >= 0.9f;

        private void Awake()
        {
                _rb = GetComponent<Rigidbody2D>();
                _player = GetComponent<Player>();
                _input = GetComponent<PlayerInput>();
        }

        private void FixedUpdate()
        {
                if (_rb.velocity.y < 0)
                {
                        _rb.gravityScale = fallMultiplier;
                }
                else if (_rb.velocity.y > 0 && !Jumping)
                {
                        _rb.gravityScale = lowJumpMultiplier;
                }
                else
                {
                        _rb.gravityScale = 1f;
                }
        }
}