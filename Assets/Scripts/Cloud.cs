using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cloud : MonoBehaviour
{
    Camera _camera;
    private CameraController _cameraController;
    private RectTransform _rectTransform;

    private float WrapLength
    {
        get
        {
            return _rectTransform.rect.width/2;
        }
    }

    private Vector2 WrapPosition
    {
        get
        {
            return new Vector2((CameraPosition % WrapLength), 0);
        }
    }

    /**
     * Returns the position of the left side of the camera viewport
     */
    private float CameraPosition
    {
        get
        {
            return _camera.transform.position.x-_cameraController.CameraHorizontalExtent;
        }
    }

    public float cameraPos;

    

    private void Awake()
    {
        _camera = GetComponentInParent<PlayerInput>().camera;
        _cameraController = _camera.GetComponent<CameraController>();
        _rectTransform = GetComponent<RectTransform>();
    }

    private void LateUpdate()
    {
        _rectTransform.anchoredPosition = -WrapPosition;
        cameraPos = CameraPosition;
    }
}
