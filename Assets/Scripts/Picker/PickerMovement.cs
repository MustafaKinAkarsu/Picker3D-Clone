using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickerMovement : MonoBehaviour
{

    Camera _pickerCamera;
    public float moveSpeed = 5.0f;
    public float forwardSpeed = 5.0f;
    float _distanceToScreen;
    private Vector3 _mousePos;
    private float _xSpeed;
    private float _forwardSpeed;
    private bool isActive = true;

    private void Start()
    {
        _forwardSpeed = 5f;
        _xSpeed = 10f;
        _pickerCamera = Camera.main;

    }
    public void Activate()
    {
        isActive = true;
    }
    public void Deactivate()
    {
        isActive = false;
    }
    private void FixedUpdate()
    {
        if (!isActive)
            return;

        if (Input.GetMouseButton(0))
        {

            var position = Input.mousePosition;

            _distanceToScreen = _pickerCamera.WorldToScreenPoint(gameObject.transform.position).z;
            _mousePos = _pickerCamera.ScreenToWorldPoint(new Vector3(position.x, position.y, _distanceToScreen));
            float direction = _xSpeed;
            direction = _mousePos.x > transform.position.x ? direction : -direction;

            if (Math.Abs(_mousePos.x - transform.position.x) > 0.5f)
                transform.Translate(Time.deltaTime * direction, 0, 0);
        }
        transform.Translate(0, 0, Time.deltaTime * _forwardSpeed);
    }
    //private void FixedUpdate() //for mobile
    //{
    //    if (!isActive)
    //        return;

    //    if (Input.touchCount > 0)
    //    {

    //        var touch = Input.GetTouch(0);

    //        if (touch.phase == TouchPhase.Moved)
    //        {
    //            var position = touch.position;

    //            _distanceToScreen = _pickerCamera.WorldToScreenPoint(gameObject.transform.position).z;
    //            _touchPos = _pickerCamera.ScreenToWorldPoint(new Vector3(position.x, position.y, _distanceToScreen));
    //            float direction = _xSpeed;
    //            direction = _touchPos.x > transform.position.x ? direction : -direction;

    //            if (Math.Abs(_touchPos.x - transform.position.x) > 0.5f)
    //                transform.Translate(Time.deltaTime * direction, 0, 0);
    //        }
    //    }
    //    transform.Translate(0, 0, Time.deltaTime * _forwardSpeed);
    //}
}
