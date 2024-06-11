using System;
using System.Collections;
using System.Collections.Generic;
using Sources;
using UnityEngine;

public class CameraRotationHandler : MonoBehaviour
{
    [SerializeField] private TestInputManager _inputManager;
    [SerializeField] private Transform _rotationTarget;
    [SerializeField] private float _sensitivity = 1;
    [SerializeField] private float _minVerticalAngle = -30;
    [SerializeField] private float _maxVerticalAngle = 30;

    private float _horizontal = 0;
    private float _vertical = 0;

    private void OnEnable()
    {
        _inputManager.RotationInputReceived += OnRotationInputReceived;
    }

    private void OnDisable()
    {
        _inputManager.RotationInputReceived -= OnRotationInputReceived;
    }

    private void OnRotationInputReceived(Vector2 delta)
    {
        float time = Time.deltaTime;

        _vertical -= _sensitivity * delta.y * time;
        _horizontal += _sensitivity * delta.x * time;

        _vertical = Mathf.Clamp(_vertical, _minVerticalAngle, _maxVerticalAngle);

        _rotationTarget.eulerAngles = new Vector3(_vertical, _horizontal, 0);
    }
}
