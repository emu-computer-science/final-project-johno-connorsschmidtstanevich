using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Cloud : MonoBehaviour
{
    private Camera _camera;
    private CameraController _cameraController;
    private RectTransform _rectTransform;
    private Image _image;

    private float WrapLength => HorizontalTileSize;

    private Vector2 WrapPosition => new Vector2(CameraPosition % WrapLength, 0);

    private float HorizontalTileSize => _image.sprite.texture.width * _image.rectTransform.localScale.x;
    
    private int TilesNeeded => Mathf.CeilToInt(_cameraController.CameraHorizontalExtent * 2 / HorizontalTileSize);

    private void Initialize()
    {
        _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, HorizontalTileSize * Mathf.Max(TilesNeeded, 4));
    }

    /**
     * Returns the position of the left side of the camera viewport
     */
    private float CameraPosition => _camera.transform.position.x - _cameraController.CameraHorizontalExtent;

    private void Awake()
    {
        _camera = GetComponentInParent<PlayerInput>().camera;
        _cameraController = _camera.GetComponent<CameraController>();
        _rectTransform = GetComponent<RectTransform>();
        _image = GetComponent<Image>();
        Initialize();
    }

    private void LateUpdate()
    {
        _rectTransform.anchoredPosition = -WrapPosition;
    }
}
