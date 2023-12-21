using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Camera _pickerCamera;
    private Vector3 _cameraOffset;



    // Start is called before the first frame update
    void Start()
    {
        _pickerCamera = Camera.main;
        _cameraOffset = _pickerCamera.transform.position - transform.position;
    }
    public Vector3 GetCameraOffset()
    {
        return _cameraOffset;
    }
    public void SetCameraOffset(float x, float y, float z)
    {
        _cameraOffset = new Vector3(x, y, z);
    }
    private void LateUpdate()
    {
        if (_pickerCamera == null)
            return;

        _pickerCamera.transform.position = new Vector3(_pickerCamera.transform.position.x, _pickerCamera.transform.position.y,
            transform.position.z + _cameraOffset.z);
    }
}
