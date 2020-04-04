using System;
using UnityEngine;

public class JumpPhysics : MonoBehaviour
{
        [Header("Set in Inspector")]
        public float fallMultiplier;
        public float lowJumpMultiplier;
        
        private Rigidbody2D _rb;
        private Player _player;

        private void Awake()
        {
                _rb = GetComponent<Rigidbody2D>();
                _player = GetComponent<Player>();
        }

        private void FixedUpdate()
        {
                if (_rb.velocity.y < 0)
                {
                        _rb.gravityScale = fallMultiplier;
                }
                else if (_rb.velocity.y > 0 && !_player.IsJumping)
                {
                        _rb.gravityScale = lowJumpMultiplier;
                }
                else
                {
                        _rb.gravityScale = 1f;
                }
        }
}