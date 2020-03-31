using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;

public class CameraController : MonoBehaviour
{
        [CanBeNull] public GameObject player;

        public Vector3 offset;

        private Vector3 CameraPos
        {
                get => transform.position;
                set => transform.position = value;
        }
        
        private  Vector3 PlayerPos
        {
                get
                {
                        if (player != null) return new Vector3(player.transform.position.x, 0, 0);
                        return default;
                }
        }

        private void Awake()
        {
                // Debug.Log(offset);
                offset = new Vector3(0,0,-10);
                CameraPos = offset;
                if (player != null) offset = CameraPos - PlayerPos;
        }

        private void LateUpdate()
        {
                if (player != null) CameraPos = PlayerPos + offset;
        }
}