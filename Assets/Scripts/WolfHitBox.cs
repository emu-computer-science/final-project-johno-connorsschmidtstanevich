﻿using System;
using UnityEngine;

public class WolfHitBox : MonoBehaviour
{
        public Player _player;
        
        private Collider2D _collider;

        public Vector2 LaunchAngle
        {
                get
                {
                        return new Vector2();
                }
        }

        private void Awake()
        {
                _collider = GetComponent<Collider2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
                if(other.gameObject.CompareTag("Hurtbox")) Debug.Log($"Hit {other.gameObject.name}");
        }
}