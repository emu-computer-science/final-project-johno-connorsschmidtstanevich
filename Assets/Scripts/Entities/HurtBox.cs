using System;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
        public GameObject parent;

        private Collider2D _collider;

        private void Awake()
        {
                _collider = GetComponent<Collider2D>();
        }
}