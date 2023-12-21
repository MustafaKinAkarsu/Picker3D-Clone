using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragToStart : MonoBehaviour
{
    PickerMovement pickerMovement;
    [SerializeField] GameObject progressCanvas;
    // Start is called before the first frame update
    private void Start()
    {
        pickerMovement = FindObjectOfType<PickerMovement>();
    }
    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            pickerMovement.enabled = true;
            progressCanvas.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
    //private void FixedUpdate() //for mobile
    //{
    //    if (Input.touchCount > 0)
    //    {
    //        var touch = Input.GetTouch(0);
    //        if (touch.phase == TouchPhase.Began)
    //        {
    //            pickerMovement.enabled = true;
    //            progressCanvas.SetActive(true);
    //            this.gameObject.SetActive(false);
    //        }
    //    }
    //}
}
