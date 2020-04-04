using System;
using UnityEngine;

public class JumpPhysics : MonoBehaviour
{
        [Header("Set in Inspector")]
        public float fallMultiplier;
        public float lowJumpMultiplier;
        
        private Rigidbody2D _rb;

        private void Awake()
        {
                _rb = GetComponent<Rigidbody2D>();
        }
}